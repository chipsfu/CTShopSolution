using CTShopSolution.ViewModels.Common;
using CTShopSolution.ViewModels.System.Users;
using System.Threading.Tasks;

namespace CTShopSolution.AdminApp.Services
{
    public interface IUserApiClient
   {
       Task<string> Authenticate(LoginRequest request);
       Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
       Task<bool> RegisterUser(RegisterRequest request);
   }
}
