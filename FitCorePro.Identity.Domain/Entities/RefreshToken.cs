namespace FitCorePro.Identity.Domain.Entities
{
    public class RefreshToken
    {
        protected RefreshToken() { }

        public RefreshToken(string id, string token, string usuarioId, DateTime expiresAt)
        {
            Id = id;
            Token = token;
            UsuarioId = usuarioId;
            ExpiresAt = expiresAt;
            CreatedDate = DateTime.Now;
            Revogado = false;
        }

        public string Id { get; private set; } = default!;
        public string Token { get; private set; } = default!;
        public string UsuarioId { get; private set; } = default!;
        public DateTime ExpiresAt { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool Revogado { get; private set; }

        public Usuario Usuario { get; private set; } = default!;

        public bool EstaAtivo => !Revogado && ExpiresAt > DateTime.UtcNow;

        public void Revogar() => Revogado = true;
    }
}