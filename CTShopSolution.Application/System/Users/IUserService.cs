using CTShopSolution.ViewModels.Common;
using CTShopSolution.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace CTShopSolution.Application.System.Users
{
    public interface IUserService
   {



       Task<ApiResult<string>> Authenticate(LoginRequest request);

       Task<ApiResult<bool>> Register(RegisterRequest request);

      // Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

       Task<ApiResult<PagedResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);

       Task<ApiResult<UserViewModel>> GetById(Guid id);
    }
}
