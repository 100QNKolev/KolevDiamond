using KolevDiamond.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolevDiamond.Infrastructure.Data.SeedDb
{
    public class MetalBarConfiguration : IEntityTypeConfiguration<MetalBar>
    {
        public void Configure(EntityTypeBuilder<MetalBar> builder)
        {
            var data = new SeedData();
            builder.HasData(new MetalBar[] { data.FirstMetalBar, data.SecondMetalBar, data.ThirdMetalBar });
        }
    }
}
