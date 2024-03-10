using AutoMapper;
using DevTesteInovage.Application.Models;
using DevTesteInovage.Application.Services.Interfaces;
using DevTesteInovage.Core.Entities;
using DevTesteInovage.Core.Repositories;

namespace DevTesteInovage.Application.Services.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task AddPurchaseAsync(AddPurchaseInputModel model)
        {
            var purchaseEntity = new Purchase(model.Description, model.DeliveryAdress);

            await _purchaseRepository.AddAsync(purchaseEntity);

            model.Id = purchaseEntity.Id;
        }

        public async Task<bool> DeliveredPurchaseAsync(UpdatePurchaseInputModel model)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(model.Id);

            if (purchase.Delivered())
            {
                await _purchaseRepository.UpdateAsync(purchase);
                return true;
            }

            return false;
        }

        public async Task<bool> CancelledPurchaseAsync(UpdatePurchaseInputModel model)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(model.Id);

            if (purchase.Cancel())
            {
                await _purchaseRepository.UpdateAsync(purchase);
                return true;
            }

            return false;
        }

        public async Task<PurchaseViewModel> GetPurchaseByIdAsync(int id)
        {
            var purchaseEntity = await _purchaseRepository.GetByIdAsync(id);

            return _mapper.Map<PurchaseViewModel>(purchaseEntity);
        }

        public async Task<PurchaseDetailsViewModel> GetPurchaseDetailsByIdAsync(int id)
        {
            var purchaseEntity = await _purchaseRepository.GetDetailsByIdAsync(id);

            return _mapper.Map<PurchaseDetailsViewModel>(purchaseEntity);
        }

        public async Task<List<PurchaseViewModel>> GetPurchasesAsync()
        {
            var purchaseEntity = await _purchaseRepository.GetAllAsync();

            return _mapper.Map<List<PurchaseViewModel>>(purchaseEntity);
        }

        public async Task<bool> OnTheWayPurchaseAsync(UpdatePurchaseInputModel model)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(model.Id);

            if (purchase.OnTheWay())
            {
                await _purchaseRepository.UpdateAsync(purchase);
                return true;
            }

            return false;
        }
    }
}
