using System.Threading.Tasks;
using AucService.Model;

namespace AucService.Services
{
    public interface IAuthService
    {
        Task<Test> TestApi();
        Task<string> Register(User user);
        Task<string> LogIn(UserRequest request);
    }
}