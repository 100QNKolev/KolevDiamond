namespace KolevDiamond.Core.Models
{
    public class ProductQueryModel
    {
        public int ProductsPerPage { get; } = 2;
        public string ProductType { get; set; } = null!;
        public decimal? PriceFilter { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalProductCount { get; set; }
        public bool IsForSale { get; set; } = true;
        public IEnumerable<ProductIndexServiceModel> Products { get; set; } = new List<ProductIndexServiceModel>();
    }
}
