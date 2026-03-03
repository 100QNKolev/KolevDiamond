using KolevDiamond.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolevDiamond.Infrastructure.Data.SeedDb
{
    public class InvestmentCoinConfiguration : IEntityTypeConfiguration<InvestmentCoin>
    {
        public void Configure(EntityTypeBuilder<InvestmentCoin> builder)
        {
            var data = new SeedData();
            builder.HasData(new InvestmentCoin[] { data.FirstInvestmentCoin, data.SecondInvestmentCoin, data.ThirdInvestmentCoin });
        }
    }
}
