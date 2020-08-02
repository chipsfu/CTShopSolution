using CTShopSolution.ViewModels.Common;

namespace CTShopSolution.ViewModels.Catalog.Products.Public
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; } //nhan ca null
    }
}
