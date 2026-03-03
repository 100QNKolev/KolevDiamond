using KolevDiamond.Core.Contracts.MetalBar;
using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.MetalBar;
using KolevDiamond.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamond.Core.Services.MetalBar
{
    public class MetalBarService : IMetalBarService
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public MetalBarService(IRepository repository, ILogger<MetalBarService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Infrastructure.Data.Models.MetalBar>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.MetalBar?> GetByIdAsyncAsTracking(int id)
        {
            return await _repository
                .All<Infrastructure.Data.Models.MetalBar>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredMetalBarsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var metalBars = _repository
                .AllReadOnly<Infrastructure.Data.Models.MetalBar>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Infrastructure.Data.Models.MetalBar),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
                metalBars = metalBars.Where(r => r.Price <= priceFilter);

            var toShow = await metalBars
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel
            {
                Products = toShow,
                TotalProductCount = metalBars.Count(),
                ProductType = nameof(Infrastructure.Data.Models.MetalBar)
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

        public async Task Create(MetalBarModel model)
        {
            var entity = new Infrastructure.Data.Models.MetalBar
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Metal = model.Metal,
                Weight = model.Weight,
                Dimensions = model.Dimensions,
                Purity = model.Purity,
                IsForSale = model.IsForSale
            };
            try
            {
                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task Update(int id, MetalBarModel model)
        {
            var entity = await GetByIdAsyncAsTracking(id);
            if (entity == null)
                throw new ApplicationException("Database failed to find metal bar info");

            entity.Name = model.Name;
            entity.ImagePath = model.ImagePath;
            entity.Price = model.Price;
            entity.Metal = model.Metal;
            entity.Weight = model.Weight;
            entity.Dimensions = model.Dimensions;
            entity.Purity = model.Purity;
            entity.IsForSale = model.IsForSale;

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(nameof(Update), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }
    }
}
