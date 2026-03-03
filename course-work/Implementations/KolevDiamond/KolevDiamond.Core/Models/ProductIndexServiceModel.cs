using KolevDiamond.Core.Contracts;

namespace KolevDiamond.Core.Models
{
    public class ProductIndexServiceModel : IProductModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public bool IsForSale { get; set; }
    }
}
