using KolevDiamond.Infrastructure.Data.Models;
using KolevDiamond.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KolevDiamond.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ring> Rings { get; set; } = null!;
        public DbSet<Necklace> Necklaces { get; set; } = null!;
        public DbSet<InvestmentDiamond> InvestmentDiamonds { get; set; } = null!;
        public DbSet<InvestmentCoin> InvestmentCoins { get; set; } = null!;
        public DbSet<MetalBar> MetalBars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RingConfiguration());
            builder.ApplyConfiguration(new NecklaceConfiguration());
            builder.ApplyConfiguration(new MetalBarConfiguration());
            builder.ApplyConfiguration(new InvestmentCoinConfiguration());
            builder.ApplyConfiguration(new InvestmentDiamondConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
