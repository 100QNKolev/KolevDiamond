using KolevDiamond.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Infrastructure.Data.Models
{
    [Comment("Necklace specifications")]
    public class Necklace
    {
        [Key]
        [Comment("Necklace unique identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the necklace")]
        [MaxLength(NecklaceNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Server file system image path")]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        [Comment("Price of the product")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Metal, which necklace is made of")]
        public MetalVariation Metal { get; set; }

        [Required]
        [Comment("How much carats is the main diamond used in the necklace")]
        public double Carats { get; set; }

        [Required]
        [Comment("What color is the main diamond")]
        public DiamondColor Colour { get; set; }

        [Required]
        [Comment("What clarity is the main diamond in the necklace")]
        public DiamondClarity Clarity { get; set; }

        [Required]
        [Comment("How well the diamond is cut")]
        public DiamondCut Cut { get; set; }

        [Required]
        [Comment("Purity of the metal expressed in carat for gold or sample for silver")]
        [MaxLength(NecklacePurityMaximumLength)]
        public string Purity { get; set; } = string.Empty;

        [Required]
        [Comment("Length of the necklace in millimeters")]
        public double Length { get; set; }

        [Required]
        [Comment("Is the item for sale")]
        public bool IsForSale { get; set; } = true;
    }
}
