
using System.Collections.Generic;
using System.Threading.Tasks;
using CTShopSolution.ViewModels.Catalog.Products;
using CTShopSolution.ViewModels.Common;

namespace CTShopSolution.Application.Catalog.Products
{
    //ko de chung Admin voi public
    // Interface nay chuyen chua phuong thuc cho ben ngoai, nguoi dung
    public interface IPublicProductService
   {
       Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

   }
}
