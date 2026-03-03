using KolevDiamond.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolevDiamond.Infrastructure.Data.SeedDb
{
    public class RingConfiguration : IEntityTypeConfiguration<Ring>
    {
        public void Configure(EntityTypeBuilder<Ring> builder)
        {
            var data = new SeedData();
            builder.HasData(new Ring[] { data.FirstRing, data.SecondRing, data.ThirdRing });
        }
    }
}
