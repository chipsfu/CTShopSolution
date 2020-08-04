using CTShopSolution.Application.Catalog.Products;
using CTShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CTShopSolution.Application.Catalog.ProductImages;
using Microsoft.AspNetCore.Authorization;

namespace CTShopSolution.BackendApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        ////GET api/products
        //[HttpGet("languageId")]
        //public async Task<IActionResult> GetAll(string languageId)
        //{
        //    var products = await _publicProductService.GetAll(languageId);
        //    return Ok(products);
        //}


        // public-paging/
        // api/products?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request) //mot param attribute chi dinh map tu dau tu query
        {
            var product = await _productService.GetAllByCategoryId(languageId, request);
            return Ok(product);
        }

        //GET api/products/id
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request) //mot param attribute chi dinh map tu dau vd tat ca thuoc tinh form data
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.LanguageId);
            //return Created(nameof(GetById), productId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest request) //mot param attribute chi dinh map tu dau vd tu body
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var effectedResult = await _productService.Update(request);
            if (effectedResult == 0)
                return BadRequest();

            return Ok();
        }


        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId) //mot param attribute chi dinh map tu dau vd tu body
        {
            var product = await _productService.Delete(productId);

            return Ok();
        }


        //[HttpPut("price/{id}/{newPrice}")]
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice) //mot param attribute chi dinh map tu dau vd tu body
        {
            var isSuccessful = await _productService.UpdatePrice(productId, newPrice);
            if (!isSuccessful)
                return BadRequest();
            return Ok();
        }

        //IMAGE
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request) //mot param attribute chi dinh map tu dau vd tat ca thuoc tinh form data
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product with id {imageId}");
            return Ok(image);
        }


        //IMAGE Update
        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request) //mot param attribute chi dinh map tu dau vd tat ca thuoc tinh form data
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        //IMAGE Update
        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId) //mot param attribute chi dinh map tu dau vd tat ca thuoc tinh form data
        {
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
