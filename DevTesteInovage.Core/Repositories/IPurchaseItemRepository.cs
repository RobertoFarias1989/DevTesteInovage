using DevTesteInovage.Core.Entities;

namespace DevTesteInovage.Core.Repositories
{
    public interface IPurchaseItemRepository
    {
        Task<PurchaseItem> GetByIdAsync(int id);
        Task AddAsync(PurchaseItem items);
        Task UpdateAsync(PurchaseItem items);
        Task DeleteAsync(int id);
    }
}
