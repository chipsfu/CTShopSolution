﻿using CTShopSolution.Data.EF;
using CTShopSolution.Data.Entities;
using CTShopSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CTShopSolution.Application.Common;
using CTShopSolution.ViewModels.Catalog.Products;

using CTShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;

namespace CTShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly CtShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(CtShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }


        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                }
            };

            //SAVE IMAGE
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail"+request.Name,
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            //find id from product
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations
                            .FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);

            if (product == null) throw new CTShopException($"Cannot find a product: {request.Id}");
            //map productTranslation
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.SeoDescription = request.Description;
            productTranslations.Details = request.Details;

            //Update IMAGE
            if (request.ThumbnailImage != null)
            {
                //select thumbnail
                var thumbnailImage = await _context.ProductImages
                                           .FirstOrDefaultAsync((x => x.IsDefault == true && x.ProductId == request.Id));
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync(); // return > 0 successful
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new CTShopException("Cannot find a product = " + productId);


            var images =  _context.ProductImages.Where(x=> x.ProductId == productId);
            foreach (var image in images)
            {
              await _storageService.DeleteFileAsync(image.ImagePath);

            }
            _context.Products.Remove(product);


            return await _context.SaveChangesAsync();
        }


        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if(product == null) throw new CTShopException($"Cannot find a product with id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0; // return bool > 0 true
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new CTShopException($"Cannot find a product with id: {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }


        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //JOIN
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.Name.Contains(request.Keyword)
                        select new { p, pt, pic };
            //Filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            if (request.CategoryIds.Count > 0)
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));

            //Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
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

        public Task<int> AddImages(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImages(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
