namespace ECommerce.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterAsync(string email, string password);
        Task Lotout();
    }
}
