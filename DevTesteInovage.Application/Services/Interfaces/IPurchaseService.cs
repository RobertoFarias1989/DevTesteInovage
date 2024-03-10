using DevTesteInovage.Application.Models;

namespace DevTesteInovage.Application.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<List<PurchaseViewModel>> GetPurchasesAsync();
        Task<PurchaseViewModel> GetPurchaseByIdAsync(int id);
        Task<PurchaseDetailsViewModel> GetPurchaseDetailsByIdAsync(int id);
        Task AddPurchaseAsync(AddPurchaseInputModel model);
        Task<bool> OnTheWayPurchaseAsync(UpdatePurchaseInputModel model);
        Task<bool> DeliveredPurchaseAsync(UpdatePurchaseInputModel model);
        Task<bool> CancelledPurchaseAsync(UpdatePurchaseInputModel model);
    }
}
