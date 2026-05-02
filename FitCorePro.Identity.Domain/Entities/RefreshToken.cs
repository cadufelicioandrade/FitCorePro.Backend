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

        public string Id { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string UsuarioId { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Revogado { get; set; }

        public Usuario Usuario { get; set; } = default!;

        public bool EstaAtivo => !Revogado && ExpiresAt > DateTime.UtcNow;

        public void Revogar() => Revogado = true;
    }
}