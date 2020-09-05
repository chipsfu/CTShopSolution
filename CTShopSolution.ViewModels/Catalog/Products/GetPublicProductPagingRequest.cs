using CTShopSolution.ViewModels.Common;

namespace CTShopSolution.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagedResultBase
    {
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; } //nhan ca null
    }
}
