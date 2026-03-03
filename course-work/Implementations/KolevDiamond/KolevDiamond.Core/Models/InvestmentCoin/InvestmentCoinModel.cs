using KolevDiamond.Core.Constants;
using KolevDiamond.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Core.Models.InvestmentCoin
{
    public class InvestmentCoinModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.NameRequired)]
        [StringLength(InvestmentCoinNameMaximumLength, MinimumLength = InvestmentCoinNameMinimumLength, ErrorMessage = ValidationMessagesConstants.NameLength)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.ImagePathRequired)]
        public string ImagePath { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.PriceRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.PriceRange)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.MetalRequired)]
        public MetalVariation Metal { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.WeightRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.WeightRange)]
        public double Weight { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.PurityRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.PurityRange)]
        public double Purity { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.QualityRequired)]
        public GoldQuality Quality { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.CirculationRequired)]
        public int Circulation { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.DiameterRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.DiameterRange)]
        public double Diameter { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.LegalTenderRequired)]
        [StringLength(InvestmentCoinLegalTenderMaximumLength, MinimumLength = InvestmentCoinLegalTenderMinimumLength, ErrorMessage = ValidationMessagesConstants.LegalTenderLength)]
        public string LegalTender { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.ManufacturerRequired)]
        [StringLength(InvestmentCoinManufacturerMaximumLength, MinimumLength = InvestmentCoinManufacturerMinimumLength, ErrorMessage = ValidationMessagesConstants.ManufacturerLength)]
        public string Manufacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.PackagingRequired)]
        [StringLength(InvestmentCoinPackagingMaximumLength, MinimumLength = InvestmentCoinPackagingMinimumLength, ErrorMessage = ValidationMessagesConstants.PackagingLength)]
        public string Packaging { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.IsForSaleRequired)]
        public bool IsForSale { get; set; } = true;
    }
}
