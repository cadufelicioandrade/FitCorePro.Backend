namespace FitCorePro.Identity.Application.Interfaces
{
    public interface IUserContext
    {
        string? GetUserId();
        string? GetEmail();
        string? GetRole();
    }
}
