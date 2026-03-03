using KolevDiamond.Core.Contracts.InvestmentDiamond;
using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.InvestmentDiamond;
using KolevDiamond.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KolevDiamond.Core.Services.InvestmentDiamond
{
    public class InvestmentDiamondService : IInvestmentDiamondService
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public InvestmentDiamondService(IRepository repository, ILogger<InvestmentDiamondService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsyncAsTracking(int id)
        {
            return await _repository
                .All<Infrastructure.Data.Models.InvestmentDiamond>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ProductQueryModel> GetFilteredInvestmentDiamondsAsync(decimal? priceFilter, int currentPage = 1, int productsPerPage = 1, bool isForSale = true)
        {
            var investmentDiamonds = _repository
                .AllReadOnly<Infrastructure.Data.Models.InvestmentDiamond>()
                .Where(r => r.IsForSale == isForSale)
                .OrderByDescending(r => r.Id)
                .Select(r => new ProductIndexServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    ImagePath = r.ImagePath,
                    Price = r.Price,
                    ProductType = nameof(Infrastructure.Data.Models.InvestmentDiamond),
                    IsForSale = r.IsForSale
                });

            if (priceFilter != null)
                investmentDiamonds = investmentDiamonds.Where(r => r.Price <= priceFilter);

            var toShow = await investmentDiamonds
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToListAsync();

            return new ProductQueryModel
            {
                Products = toShow,
                TotalProductCount = investmentDiamonds.Count(),
                ProductType = nameof(Infrastructure.Data.Models.InvestmentDiamond)
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

        public async Task Create(InvestmentDiamondModel model)
        {
            var entity = new Infrastructure.Data.Models.InvestmentDiamond
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Price = model.Price,
                Carats = model.Carats,
                Colour = model.Colour,
                Clarity = model.Clarity,
                Cut = model.Cut,
                CertifyingLaboratory = model.CertifyingLaboratory,
                Proportions = model.Proportions,
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

        public async Task Update(int id, InvestmentDiamondModel model)
        {
            var entity = await GetByIdAsyncAsTracking(id);
            if (entity == null)
                throw new ApplicationException("Database failed to find investment diamond info");

            entity.Name = model.Name;
            entity.ImagePath = model.ImagePath;
            entity.Price = model.Price;
            entity.Carats = model.Carats;
            entity.Colour = model.Colour;
            entity.Clarity = model.Clarity;
            entity.Cut = model.Cut;
            entity.CertifyingLaboratory = model.CertifyingLaboratory;
            entity.Proportions = model.Proportions;
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
