using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CTShopSolution.Application.Catalog.Products.Dtos;
using CTShopSolution.Application.Dtos;

namespace CTShopSolution.Application.Catalog.Products
{
   public interface IManageProductService
   {
       //Interface cho admin them sua xoa
       Task<int> Create(ProductCreateRequest request);

       Task<int> Update(ProductEditRequest request);
       Task<int> Delete(int productId);
        //lay danh sach product muon hien thi
        Task<List<ProductViewModel>>  GetAll();

        Task<PagedViewModel<ProductViewModel>>  GetAllPaging(string keyword, int pageIndex, int pageSize);
   }
}
