using DevTesteInovage.Application.Models;

namespace DevTesteInovage.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(int id);
        Task AddProductAsync(AddProductInputModel model);
        Task UpdateProductAsync(UpdateProductInputModel model);
        Task InactivedProductAsync(InactivedProductInputModel model);
    }
}
