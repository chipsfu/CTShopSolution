
using CTShopSolution.Application.Catalog.ProductImages;
using CTShopSolution.ViewModels.Catalog.Products;
using CTShopSolution.ViewModels.Common;
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
       Task<ProductViewModel> GetById(int productId, string languageId);


       Task<bool> UpdatePrice(int productId, decimal newPrice);
       Task<bool> UpdateStock(int productId, int addedQuantity);
       Task AddViewCount(int productId);


        //lay danh sach product muon hien thi
        //Task<List<ProductViewModel>>  GetAll();

        Task<PagedResult<ProductViewModel>>  GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<ProductImageViewModel> GetImageById(int imageId);


   }
}
