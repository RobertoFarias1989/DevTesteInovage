using DevTesteInovage.Application.Models;

namespace DevTesteInovage.Application.Services.Interfaces
{
    public interface IPurchaseItemService
    {
        Task<PurchaseItemViewModel> GetPurchaseItensByIdAsync(int id);
        Task AddPurchaseItemAsync(int productId,int purchaseId,AddPurchaseItemInputModel model);
        Task UpdatePurchaseItemAsync(UpdatePurchaseItemInputModel model);
        Task DeletePurchaseItemAsync(int id);
    }
}
