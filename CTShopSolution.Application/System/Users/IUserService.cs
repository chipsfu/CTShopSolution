using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CTShopSolution.ViewModels.Common;
using CTShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTShopSolution.Application.System.Users
{
   public interface IUserService
   {
       Task<string> Authenticate(LoginRequest request);
       Task<bool> Register(RegisterRequest request);
       Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
   }
}
