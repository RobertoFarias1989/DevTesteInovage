using DevTesteInovage.Core.Entities;

namespace DevTesteInovage.Core.Repositories
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(int id);
        Task<Purchase> GetDetailsByIdAsync(int id);
        Task AddAsync(Purchase purchase);
        Task UpdateAsync(Purchase purchase);
        Task OnTheWayAsync(int id);
        Task DeliveredAsync(int id);
    }
}
