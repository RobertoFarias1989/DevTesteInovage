using DevTesteInovage.Core.Entities;
using DevTesteInovage.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevTesteInovage.Infrastructure.Persistence.Repositories
{
    public class PurchaseItemRepository : IPurchaseItemRepository
    {
        private readonly DevTesteInovageDbContext _dbContext;

        public PurchaseItemRepository(DevTesteInovageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PurchaseItem items)
        {
            var product = await _dbContext.Products
                .Where(p => p.Id == items.IdProduct)
                .SingleOrDefaultAsync();

            var purchase = await _dbContext.Purchases
                .Where(p => p.Id == items.IdPurchase)
                .SingleOrDefaultAsync();

            if (product.Active == true && purchase.Status != Core.Enums.PurchaseStatusEnum.Cancelled)
            {
                await _dbContext.PurchaseItems.AddAsync(items);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
               throw new InvalidOperationException($"Product {product.Id} isn't active or Purchase {purchase.Id} is cancelled.");
            }


        }

        public async Task<PurchaseItem> GetByIdAsync(int id)
        {
            return await _dbContext.PurchaseItems.SingleOrDefaultAsync(pi => pi.Id == id);
        }

        public async Task UpdateAsync(PurchaseItem items)
        {
            _dbContext.PurchaseItems.Update(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.PurchaseItems.SingleOrDefaultAsync(pi => pi.Id == id);

            if (entity != null)
            {
                _dbContext.PurchaseItems.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
