using KolevDiamond.Core.Contracts;
using KolevDiamond.Infrastructure.Enums;

namespace KolevDiamond.Core.Models.InvestmentCoin
{
    public class InvestmentCoinDetailsServiceModel : IProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public MetalVariation Metal { get; set; }
        public double Weight { get; set; }
        public double Purity { get; set; }
        public GoldQuality Quality { get; set; }
        public int Circulation { get; set; }
        public double Diameter { get; set; }
        public string LegalTender { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Packaging { get; set; } = string.Empty;
    }
}
