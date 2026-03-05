using KolevDiamond.Core.Constants;
using KolevDiamond.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Core.Models.MetalBar
{
    public class MetalBarModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.NameRequired)]
        [StringLength(MetalBarNameMaximumLength, MinimumLength = MetalBarNameMinimumLength, ErrorMessage = ValidationMessagesConstants.NameLength)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.ImagePathRequired)]
        [StringLength(ImagePathMaximumLength, MinimumLength = ImagePathMinimumLength, ErrorMessage = ValidationMessagesConstants.ImagePathLength)]
        public string ImagePath { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.PriceRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.PriceRange)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.MetalRequired)]
        public MetalVariation? Metal { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.WeightRequired)]
        [Range(0, double.MaxValue, ErrorMessage = ValidationMessagesConstants.WeightRange)]
        public double Weight { get; set; }

        [Required(ErrorMessage = ValidationMessagesConstants.DimensionsRequired)]
        [StringLength(MetalBarDimentionsMaximumLength, MinimumLength = MetalBarDimentionsMinumumLength, ErrorMessage = ValidationMessagesConstants.DimensionsLength)]
        public string Dimensions { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.PurityRequired)]
        [StringLength(MetalBarPurityMaximumLength, MinimumLength = MetalBarPurityMinumumLength, ErrorMessage = ValidationMessagesConstants.PurityLength)]
        public string Purity { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessagesConstants.IsForSaleRequired)]
        public bool IsForSale { get; set; } = true;
    }
}
