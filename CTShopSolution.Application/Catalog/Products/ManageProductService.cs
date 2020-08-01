using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CTShopSolution.Application.Catalog.Products.Dtos;
using CTShopSolution.Application.Dtos;
using CTShopSolution.Data.EF;
using CTShopSolution.Data.Entities;

namespace CTShopSolution.Application.Catalog.Products
{
   public class ManageProductService : IManageProductService
    {
        private readonly CtShopDbContext _context;

        public ManageProductService(CtShopDbContext context)
        {
            _context = context;
        }


        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
            };
            _context.Products.Add(product);
          return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
