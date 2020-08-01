using System;
using System.Collections.Generic;
using System.Text;
using CTShopSolution.Application.Catalog.Products.Dtos;
using CTShopSolution.Application.Dtos;

namespace CTShopSolution.Application.Catalog.Products
{
    //ko de chung Admin voi public
    // Interface nay chuyen chua phuong thuc cho ben ngoai, nguowif dung
   public interface IPublicProductService
   {
       PagedViewModel<ProductViewModel> GetAllByCategoryById(int categoryId, int pageIndex, int pageSize);
   }
}
