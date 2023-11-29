using Identity.Models;

namespace Identity.Helpers.Interfaces
{
    public interface IAutenticationHelper
    {
        Task<UserLogged> GenerateJwt(string email);
    }
}
