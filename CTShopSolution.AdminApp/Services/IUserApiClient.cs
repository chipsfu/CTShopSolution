using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTShopSolution.ViewModels.Common;
using CTShopSolution.ViewModels.System.Users;

namespace CTShopSolution.AdminApp.Services
{
   public interface IUserApiClient
   {
       Task<string> Authenticate(LoginRequest request);
       Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
   }
}
