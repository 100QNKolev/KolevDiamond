using KolevDiamond.Core.Contracts.Necklace;
using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Necklace;
using KolevDiamond.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamond.Core.Services.Necklace
{
    public class NecklaceService : INecklaceService
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public NecklaceService(IRepository repository, ILogger<NecklaceService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Infrastructure.Data.Models.Necklace?> GetByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.Necklace?> GetByIdAsyncAsTracking(int id)
        {
            return await _repository
                .All<Infrastructure.Data.Models.Necklace>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredNecklacesAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var necklaces = _repository
                .AllReadOnly<Infrastructure.Data.Models.Necklace>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Infrastructure.Data.Models.Necklace),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
                necklaces = necklaces.Where(r => r.Price <= priceFilter);

            var toShow = await necklaces
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel
            {
                Products = toShow,
                TotalProductCount = necklaces.Count(),
                ProductType = nameof(Infrastructure.Data.Models.Necklace)
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

        public async Task Create(NecklaceModel model)
        {
            var entity = new Infrastructure.Data.Models.Necklace
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
                Length = model.Length,
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

        public async Task Update(int id, NecklaceModel model)
        {
            var entity = await GetByIdAsyncAsTracking(id);
            if (entity == null)
                throw new ApplicationException("Database failed to find necklace info");

            entity.Name = model.Name;
            entity.ImagePath = model.ImagePath;
            entity.Price = model.Price;
            entity.Metal = model.Metal;
            entity.Carats = model.Carats;
            entity.Colour = model.Colour;
            entity.Clarity = model.Clarity;
            entity.Cut = model.Cut;
            entity.Purity = model.Purity;
            entity.Length = model.Length;
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
