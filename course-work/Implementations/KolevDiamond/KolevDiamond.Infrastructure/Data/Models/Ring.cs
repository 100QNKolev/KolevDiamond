using KolevDiamond.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Infrastructure.Data.Models
{
    [Comment("Ring specifications")]
    public class Ring
    {
        [Key]
        [Comment("Ring unique identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the ring")]
        [MaxLength(RingNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Server file system image path")]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        [Comment("Price of the product")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Metal, which ring is made of")]
        public MetalVariation Metal { get; set; }

        [Required]
        [Comment("How much carats is the main diamond used in the ring")]
        public double Carats { get; set; }

        [Required]
        [Comment("What color is the main diamond")]
        public DiamondColor Colour { get; set; }

        [Required]
        [Comment("What clarity is the main diamond in the ring")]
        public DiamondClarity Clarity { get; set; }

        [Required]
        [Comment("How well the diamond is cut")]
        public DiamondCut Cut { get; set; }

        [Required]
        [Comment("Purity of the metal expressed in carat for gold or sample for silver")]
        [MaxLength(RingPurityMaximumLength)]
        public string Purity { get; set; } = string.Empty;

        [Required]
        [Comment("Is the item for sale")]
        public bool IsForSale { get; set; } = true;
    }
}
