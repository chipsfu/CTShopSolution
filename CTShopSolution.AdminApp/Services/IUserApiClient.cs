using CTShopSolution.ViewModels.Common;
using CTShopSolution.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace CTShopSolution.AdminApp.Services
{
    public interface IUserApiClient
   {
       Task<ApiResult<string>> Authenticate(LoginRequest request);
       Task<ApiResult<PagedResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);
       Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
       Task<ApiResult<UserViewModel>> GetById(Guid id);
    }
}
