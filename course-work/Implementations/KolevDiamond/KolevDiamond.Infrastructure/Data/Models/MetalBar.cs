using KolevDiamond.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Infrastructure.Data.Models
{
    [Comment("Metal bar specifications")]
    public class MetalBar
    {
        [Key]
        [Comment("Metal bar unique identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Name of the metal bar")]
        [MaxLength(MetalBarNameMaximumLength)]
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
        [Comment("Weight of the metal bar in grams")]
        public double Weight { get; set; }

        [Required]
        [Comment("Dimensions of the metal bar (length x width)")]
        [MaxLength(MetalBarDimentionsMaximumLength)]
        public string Dimensions { get; set; } = string.Empty;

        [Required]
        [Comment("Purity of the metal expressed in carat for gold or sample for silver")]
        [MaxLength(MetalBarPurityMaximumLength)]
        public string Purity { get; set; } = string.Empty;

        [Required]
        [Comment("Is the item for sale")]
        public bool IsForSale { get; set; } = true;
    }
}
