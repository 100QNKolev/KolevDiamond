using KolevDiamond.Core.Contracts.InvestmentCoin;
using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.InvestmentCoin;
using KolevDiamond.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamond.Core.Services.InvestmentCoin
{
    public class InvestmentCoinService : IInvestmentCoinService
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public InvestmentCoinService(IRepository repository, ILogger<InvestmentCoinService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsyncAsTracking(int id)
        {
            return await _repository
                .All<Infrastructure.Data.Models.InvestmentCoin>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredInvestmentCoinsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var investmentCoins = _repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentCoin>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Infrastructure.Data.Models.InvestmentCoin),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
                investmentCoins = investmentCoins.Where(r => r.Price <= priceFilter);

            var toShow = await investmentCoins
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel
            {
                Products = toShow,
                TotalProductCount = investmentCoins.Count(),
                ProductType = nameof(Infrastructure.Data.Models.InvestmentCoin)
            };
        }

        public async Task Delete(int id)
        {
            var entity = await GetByIdAsyncAsTracking(id);
            if (entity != null)
            {
                entity.IsForSale = false;
                await _repository.SaveChangesAsync();
            }
        }

        public async Task Create(InvestmentCoinModel model)
        {
            var entity = new Infrastructure.Data.Models.InvestmentCoin
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Metal = model.Metal.Value,
                Purity = model.Purity,
                Weight = model.Weight,
                Quality = model.Quality.Value,
                Circulation = model.Circulation,
                Diameter = model.Diameter,
                LegalTender = model.LegalTender,
                Manufacturer = model.Manufacturer,
                Packaging = model.Packaging,
                IsForSale = model.IsForSale
            };
            try
            {
                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in {Method}", nameof(Create));
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task Update(int id, InvestmentCoinModel model)
        {
            var entity = await GetByIdAsyncAsTracking(id);
            if (entity == null)
                throw new ApplicationException("Database failed to find investment coin info");

            entity.Name = model.Name;
            entity.ImagePath = model.ImagePath;
            entity.Price = model.Price;
            entity.Metal = model.Metal.Value;
            entity.Purity = model.Purity;
            entity.Weight = model.Weight;
            entity.Quality = model.Quality.Value;
            entity.Circulation = model.Circulation;
            entity.Diameter = model.Diameter;
            entity.LegalTender = model.LegalTender;
            entity.Manufacturer = model.Manufacturer;
            entity.Packaging = model.Packaging;
            entity.IsForSale = model.IsForSale;

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in {Method}", nameof(Update));
                throw new ApplicationException("Database failed to save info", ex);
            }
        }
    }
}
