using FitCorePro.Identity.Application.Contracts.Requests;
using FitCorePro.Identity.Application.Contracts.Responses;
using FitCorePro.Identity.Application.Interfaces;
using FitCorePro.Identity.Domain.Constants;
using FitCorePro.Identity.Domain.Entities;
using FitCorePro.Identity.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FitCorePro.Identity.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public AuthService(
            IUsuarioRepository usuarioRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        public async Task<AuthResponse> RegistrarAsync(RegisterRequest request)
        {
            var email = request.Email.Trim().ToLower();

            var existente = await _usuarioRepository.ObterPorEmailAsync(email);
            if (existente is not null)
                throw new Exception("Já existe usuário com este email.");

            var usuario = new Usuario(
                Guid.NewGuid().ToString(),
                request.Nome.Trim(),
                email,
                string.Empty,
                Roles.User);

            var passwordHash = _passwordHasher.HashPassword(usuario, request.Senha);
            usuario.AlterarSenha(passwordHash);

            await _usuarioRepository.AdicionarAsync(usuario);

            var refreshTokenValue = _jwtTokenService.GerarRefreshToken();
            var refreshToken = new RefreshToken(
                Guid.NewGuid().ToString(),
                refreshTokenValue,
                usuario.Id,
                _jwtTokenService.ObterExpiracaoRefreshToken());

            await _refreshTokenRepository.AdicionarAsync(refreshToken);

            return new AuthResponse
            {
                AccessToken = _jwtTokenService.GerarAccessToken(usuario),
                RefreshToken = refreshTokenValue,
                ExpiresAt = _jwtTokenService.ObterExpiracaoAccessToken(),
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var email = request.Email.Trim().ToLower();

            var usuario = await _usuarioRepository.ObterPorEmailAsync(email);
            if (usuario is null || !usuario.Ativo)
                throw new Exception("Usuário ou senha inválidos.");

            var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, request.Senha);
            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Usuário ou senha inválidos.");

            var refreshTokenValue = _jwtTokenService.GerarRefreshToken();
            var refreshToken = new RefreshToken(
                Guid.NewGuid().ToString(),
                refreshTokenValue,
                usuario.Id,
                _jwtTokenService.ObterExpiracaoRefreshToken());

            await _refreshTokenRepository.AdicionarAsync(refreshToken);

            return new AuthResponse
            {
                AccessToken = _jwtTokenService.GerarAccessToken(usuario),
                RefreshToken = refreshTokenValue,
                ExpiresAt = _jwtTokenService.ObterExpiracaoAccessToken(),
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role
            };
        }

        public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var refreshToken = await _refreshTokenRepository.ObterPorTokenAsync(request.RefreshToken);
            if (refreshToken is null)
                throw new Exception("Refresh token inválido.");

            if (!refreshToken.EstaAtivo)
                throw new Exception("Refresh token expirado ou revogado.");

            var usuario = await _usuarioRepository.ObterPorIdAsync(refreshToken.UsuarioId);
            if (usuario is null || !usuario.Ativo)
                throw new Exception("Usuário inválido.");

            refreshToken.Revogar();
            await _refreshTokenRepository.AtualizarAsync(refreshToken);

            var novoRefreshTokenValue = _jwtTokenService.GerarRefreshToken();
            var novoRefreshToken = new RefreshToken(
                Guid.NewGuid().ToString(),
                novoRefreshTokenValue,
                usuario.Id,
                _jwtTokenService.ObterExpiracaoRefreshToken());

            await _refreshTokenRepository.AdicionarAsync(novoRefreshToken);

            return new AuthResponse
            {
                AccessToken = _jwtTokenService.GerarAccessToken(usuario),
                RefreshToken = novoRefreshTokenValue,
                ExpiresAt = _jwtTokenService.ObterExpiracaoAccessToken(),
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role
            };
        }

        public async Task LogoutAsync(string refreshTokenValue)
        {
            var refreshToken = await _refreshTokenRepository.ObterPorTokenAsync(refreshTokenValue);
            if (refreshToken is null)
                return;

            refreshToken.Revogar();
            await _refreshTokenRepository.AtualizarAsync(refreshToken);
        }
    }
}