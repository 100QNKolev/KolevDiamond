namespace KolevDiamond.Core.Models
{
    public class ProductQueryModel
    {
        public int ProductsPerPage { get; set; } = 2;
        public string? ProductType { get; set; }
        public decimal? PriceFilter { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalProductCount { get; set; }
        public bool IsForSale { get; set; } = true;
        public IEnumerable<ProductIndexServiceModel> Products { get; set; } = new List<ProductIndexServiceModel>();
    }
}
