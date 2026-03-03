using KolevDiamond.Core.Contracts;
using KolevDiamond.Infrastructure.Enums;

namespace KolevDiamond.Core.Models.InvestmentDiamond
{
    public class InvestmentDiamondDetailsServiceModel : IProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Carats { get; set; }
        public DiamondColor Colour { get; set; }
        public DiamondClarity Clarity { get; set; }
        public DiamondCut Cut { get; set; }
        public string CertifyingLaboratory { get; set; } = string.Empty;
        public string Proportions { get; set; } = string.Empty;
    }
}
