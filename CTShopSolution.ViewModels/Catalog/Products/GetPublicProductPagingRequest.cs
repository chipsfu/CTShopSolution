using CTShopSolution.ViewModels.Common;

namespace CTShopSolution.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; } //nhan ca null
    }
}
