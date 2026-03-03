using KolevDiamond.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Infrastructure.Data.Models
{
    [Comment("Investment diamond specifications")]
    public class InvestmentDiamond
    {
        [Key]
        [Comment("Diamond unique identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the diamond")]
        [MaxLength(InvestmentDiamondNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Server file system image path")]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        [Comment("Price of the product")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Comment("How much carats is the diamond")]
        public double Carats { get; set; }

        [Required]
        [Comment("What color is the diamond")]
        public DiamondColor Colour { get; set; }

        [Required]
        [Comment("What clarity is the diamond")]
        public DiamondClarity Clarity { get; set; }

        [Required]
        [Comment("How well the diamond is cut")]
        public DiamondCut Cut { get; set; }

        [Required]
        [Comment("The certifying gemological laboratory")]
        [MaxLength(InvestmentDiamondCertifyingLaboratoryMaximumLength)]
        public string CertifyingLaboratory { get; set; } = string.Empty;

        [Required]
        [Comment("The proportions of the diamond")]
        [MaxLength(InvestmentDiamondProportionsMaximumLength)]
        public string Proportions { get; set; } = string.Empty;

        [Required]
        [Comment("Is the item for sale")]
        public bool IsForSale { get; set; } = true;
    }
}
