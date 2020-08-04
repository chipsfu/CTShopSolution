using System;
using System.Collections.Generic;
using System.Text;
using CTShopSolution.ViewModels.Common;

namespace CTShopSolution.ViewModels.System.Users
{
   public class GetUserPagingRequest :PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
