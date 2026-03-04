using KolevDiamond.Core.Contracts;
using System.Text.RegularExpressions;

namespace KolevDiamond.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IProductModel model)
        {
            string info = model.Name.Replace(" ", "-") + GetPrice(model);
            return Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
        }

        private static string GetPrice(IProductModel model)
        {
            return model.Price.ToString();
        }
    }
}
