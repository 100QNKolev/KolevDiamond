using KolevDiamond.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Infrastructure.Data.Models
{
    [Comment("Investment coin specifications")]
    public class InvestmentCoin
    {
        [Key]
        [Comment("Coin unique identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the coin")]
        [MaxLength(InvestmentCoinNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Server file system image path")]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        [Comment("Price of the product")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Type of metal")]
        public MetalVariation Metal { get; set; }

        [Required]
        [Comment("Weight of the metal in grams")]
        public double Weight { get; set; }

        [Required]
        [Comment("Purity of the metal expressed as a ratio")]
        public double Purity { get; set; }

        [Required]
        [Comment("Quality of the metal")]
        public GoldQuality Quality { get; set; }

        [Required]
        [Comment("Number of pieces in circulation")]
        public int Circulation { get; set; }

        [Required]
        [Comment("Diameter of the coin in millimeters")]
        public double Diameter { get; set; }

        [Required]
        [Comment("Legal tender value in the specified currency")]
        [MaxLength(InvestmentCoinLegalTenderMaximumLength)]
        public string LegalTender { get; set; } = string.Empty;

        [Required]
        [Comment("Manufacturer of the coin")]
        [MaxLength(InvestmentCoinManufacturerMaximumLength)]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        [Comment("Packaging for the coin")]
        [MaxLength(InvestmentCoinPackagingMaximumLength)]
        public string Packaging { get; set; } = string.Empty;

        [Required]
        [Comment("Is the item for sale")]
        public bool IsForSale { get; set; } = true;
    }
}
