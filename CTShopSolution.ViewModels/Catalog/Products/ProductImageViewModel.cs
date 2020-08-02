namespace CTShopSolution.ViewModels.Catalog.Products
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public bool isDefault { get; set; }
        public long FileSize { get; set; }
    }
}