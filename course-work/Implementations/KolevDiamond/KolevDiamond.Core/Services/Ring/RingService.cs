using KolevDiamond.Core.Contracts.Ring;
using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Ring;
using KolevDiamond.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamond.Core.Services.Ring
{
    public class RingService : IRingService
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public RingService(IRepository repository, ILogger<RingService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Infrastructure.Data.Models.Ring?> GetByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.Ring?> GetByIdAsyncAsTracking(int id)
        {
            return await _repository
                .All<Infrastructure.Data.Models.Ring>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredRingsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var rings = _repository
                .AllReadOnly<Infrastructure.Data.Models.Ring>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Infrastructure.Data.Models.Ring),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
                rings = rings.Where(r => r.Price <= priceFilter);

            var toShow = await rings
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel
            {
                Products = toShow,
                TotalProductCount = rings.Count(),
                ProductType = nameof(Infrastructure.Data.Models.Ring)
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

        public async Task Create(RingModel model)
        {
            var entity = new Infrastructure.Data.Models.Ring
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Metal = model.Metal,
                Carats = model.Carats,
                Colour = model.Colour,
                Clarity = model.Clarity,
                Cut = model.Cut,
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

        public async Task Update(int id, RingModel model)
        {
            var entity = await GetByIdAsyncAsTracking(id);
            if (entity == null)
                throw new ApplicationException("Database failed to find ring info");

            entity.Name = model.Name;
            entity.ImagePath = model.ImagePath;
            entity.Price = model.Price;
            entity.Metal = model.Metal;
            entity.Carats = model.Carats;
            entity.Colour = model.Colour;
            entity.Clarity = model.Clarity;
            entity.Cut = model.Cut;
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
