namespace FitCorePro.Identity.Domain.Entities
{
    public class Usuario
    {
        private readonly List<RefreshToken> _refreshTokens = new();

        protected Usuario() { }

        public Usuario(string id, string nome, string email, string passwordHash, string role)
        {
            Id = id;
            Nome = nome;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            Ativo = true;
            CreatedDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = default!;
        public bool Ativo { get; set; }
        public DateOnly CreatedDate { get; set; }

        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens;

        public void AlterarSenha(string novoHash) => PasswordHash = novoHash;
        public void Inativar() => Ativo = false;
        public void Ativar() => Ativo = true;
        public void AlterarRole(string role) => Role = role;

        public void AdicionarRefreshToken(RefreshToken refreshToken)
        {
            _refreshTokens.Add(refreshToken);
        }
    }
}