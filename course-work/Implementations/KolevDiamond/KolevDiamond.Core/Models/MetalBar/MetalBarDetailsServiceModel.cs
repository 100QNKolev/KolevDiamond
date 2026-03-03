using KolevDiamond.Core.Contracts;
using KolevDiamond.Infrastructure.Enums;

namespace KolevDiamond.Core.Models.MetalBar
{
    public class MetalBarDetailsServiceModel : IProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public MetalVariation Metal { get; set; }
        public double Weight { get; set; }
        public string Dimensions { get; set; } = string.Empty;
        public string Purity { get; set; } = string.Empty;
    }
}
