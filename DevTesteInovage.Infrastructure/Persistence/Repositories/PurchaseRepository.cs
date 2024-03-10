using DevTesteInovage.Core.Entities;
using DevTesteInovage.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevTesteInovage.Infrastructure.Persistence.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DevTesteInovageDbContext _dbContext;

        public PurchaseRepository(DevTesteInovageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Purchase purchase)
        {
            await _dbContext.Purchases.AddAsync(purchase);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeliveredAsync(int id)
        {
            var purchase = await _dbContext.Purchases.SingleOrDefaultAsync(p => p.Id == id);

            purchase.Delivered();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Purchase>> GetAllAsync()
        {
            return await _dbContext.Purchases.ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return await _dbContext.Purchases.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Purchase> GetDetailsByIdAsync(int id)
        {
            return await _dbContext
                   .Purchases
                   .Include(p => p.PurchaseItems)
                   .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task OnTheWayAsync(int id)
        {
            var purchase = await _dbContext.Purchases.SingleOrDefaultAsync(p => p.Id == id);

            purchase.OnTheWay();
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            _dbContext.Update(purchase);
            await _dbContext.SaveChangesAsync();
        }
    }
}
