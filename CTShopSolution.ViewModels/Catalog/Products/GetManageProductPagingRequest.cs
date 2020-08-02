using System.Collections.Generic;
using CTShopSolution.ViewModels.Common;

namespace CTShopSolution.ViewModels.Catalog.Products
{
   public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
