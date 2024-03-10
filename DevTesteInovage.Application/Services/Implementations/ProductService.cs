using AutoMapper;
using DevTesteInovage.Application.Models;
using DevTesteInovage.Application.Services.Interfaces;
using DevTesteInovage.Core.Entities;
using DevTesteInovage.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevTesteInovage.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddProductAsync(AddProductInputModel model)
        {
            var productEntity = new Product(model.Title,model.Description,model.Price);

            await _productRepository.AddAsync(productEntity);

            model.Id = productEntity.Id;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            var productEntity = await _productRepository.GetAllAsync();

            return _mapper.Map<List<ProductViewModel>>(productEntity);
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductViewModel>(productEntity);
        }

        public async Task<ProductDetailsViewModel> GetProductDetailsByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetDetailsByIdAsync(id);

            return _mapper.Map<ProductDetailsViewModel>(productEntity);
        }

        public async Task UpdateProductAsync(UpdateProductInputModel model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);

            product.Update(model.Description, model.Price);

            await _productRepository.UpdateAsync(product);
        }

        public async Task InactivedProductAsync(InactivedProductInputModel model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);

            product.Inactived();

            await _productRepository.UpdateAsync(product);
        }
    }
}
