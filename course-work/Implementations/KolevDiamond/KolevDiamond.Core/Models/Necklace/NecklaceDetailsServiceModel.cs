using KolevDiamond.Core.Contracts;
using KolevDiamond.Infrastructure.Enums;

namespace KolevDiamond.Core.Models.Necklace
{
    public class NecklaceDetailsServiceModel : IProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public MetalVariation Metal { get; set; }
        public double Carats { get; set; }
        public DiamondColor Colour { get; set; }
        public DiamondClarity Clarity { get; set; }
        public DiamondCut Cut { get; set; }
        public string Purity { get; set; } = string.Empty;
        public double Length { get; set; }
    }
}
