using CTShopSolution.Data.EF;
using CTShopSolution.ViewModels.Catalog.Products;
using CTShopSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;
using System.Threading.Tasks;

namespace CTShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly CtShopDbContext _context;

        public PublicProductService(CtShopDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryById(GetPublicProductPagingRequest request)
        {
            //1. Query
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on pt.ProductId equals pic.ProductId
                        join c in _context.Categories on pic.ProductId equals c.Id
                        select new  {p, pt, pic};
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => request.CategoryId == p.pic.CategoryId);
            }
            //3.paging lay ra tong so dong de phan trang
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex-1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,

                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    SeoDescription = x.pt.SeoDescription

                }).ToListAsync();
            //4. Select and projection
            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,

            };
            return pageResult;
        }

    }
}
