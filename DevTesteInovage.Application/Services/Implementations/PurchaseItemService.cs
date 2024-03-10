using AutoMapper;
using DevTesteInovage.Application.Models;
using DevTesteInovage.Application.Services.Interfaces;
using DevTesteInovage.Core.Entities;
using DevTesteInovage.Core.Repositories;

namespace DevTesteInovage.Application.Services.Implementations
{
    public class PurchaseItemService : IPurchaseItemService
    {
        private readonly IPurchaseItemRepository _purchaseItemsRepository;
        private readonly IMapper _mapper;

        public PurchaseItemService(IPurchaseItemRepository purchaseItemsRepository, IMapper mapper)
        {
            _purchaseItemsRepository = purchaseItemsRepository;
            _mapper = mapper;
        }

        public async Task AddPurchaseItemAsync(int productId, int purchaseId, AddPurchaseItemInputModel model)
        {
            var entity = new PurchaseItem(model.OrderedQuantity,model.TotalPrice,model.IdPurchase,model.IdProduct);

            await _purchaseItemsRepository.AddAsync(entity);

            model.Id = entity.Id;
        }

        public async Task<PurchaseItemViewModel> GetPurchaseItensByIdAsync(int id)
        {
            var entity = await _purchaseItemsRepository.GetByIdAsync(id);

            return _mapper.Map<PurchaseItemViewModel>(entity);
        }

        public async Task UpdatePurchaseItemAsync(UpdatePurchaseItemInputModel model)
        {
            var entity = await _purchaseItemsRepository.GetByIdAsync(model.Id);

            entity.Update(model.OrderedQuantity, model.TotalPrice);

            await _purchaseItemsRepository.UpdateAsync(entity);
        }

        public async Task DeletePurchaseItemAsync(int id)
        {
            await _purchaseItemsRepository.DeleteAsync(id);
        }
    }
}
