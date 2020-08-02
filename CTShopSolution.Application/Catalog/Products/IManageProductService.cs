
using CTShopSolution.ViewModels.Catalog.Products;
using CTShopSolution.ViewModels.Catalog.Products.Manage;
using CTShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
   {
       //Interface cho admin them sua xoa
       Task<int> Create(ProductCreateRequest request);

       Task<int> Update(ProductUpdateRequest request);
       Task<int> Delete(int productId);


       Task<bool> UpdatePrice(int productId, decimal newPrice);
       Task<bool> UpdateStock(int productId, int addedQuantity);
       Task AddViewCount(int productId);


        //lay danh sach product muon hien thi
        //Task<List<ProductViewModel>>  GetAll();

        Task<PagedResult<ProductViewModel>>  GetAllPaging(GetProductPagingRequest request);

        Task<int> AddImages(int productId, List<IFormFile> files);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImages(int imageId, string caption, bool isDefault);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
   }
}
