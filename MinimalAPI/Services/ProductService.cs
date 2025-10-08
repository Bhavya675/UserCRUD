using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MinimalAPI.Entities;
using MinimalAPI.Models.DTO.Request;
using MinimalAPI.Models.DTO.Response;
using MinimalAPI.Repository.Interface;
using MinimalAPI.Services.Interface;

namespace MinimalAPI.Services
{
    public class ProductService(IProductRepository repo, IMapper _mapper) : IProductService
    {
        public async Task<List<Product>> GetAllProductsAsync() => await repo.GetAllAsync();
        public async Task<Product?> GetProductByIdAsync(int id) => await repo.GetByIdAsync(id);

        public async Task<ProductResponse> AddProductAsync(ProductDTO requestObject)
        {
            var isProductExist = await repo.NameExistsAsync(requestObject.Name);
            if (isProductExist) return GetResponse(false, "Product with the same name already exists", null);

            var product = _mapper.Map<Product>(requestObject);
            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            return GetResponse(true, "Product added successfully", new List<Product> { product });
        }

        public async Task<ProductResponse> UpdateProductAsync(int id, ProductDTO requestObject)
        {
            var record = await repo.GetByIdAsync(id);
            if (record != null)
            {
                var isProductExist = await repo.NameExistsAsync(requestObject.Name);
                if (isProductExist) return GetResponse(false, "Product with the same name already exists", null);

                _mapper.Map(requestObject, record);
                repo.Update(record);
                await repo.SaveChangesAsync();
                return GetResponse(true, "Product updated successfully", new List<Product> { record });
            }
            else
            {
                return GetResponse(false, "Product not found", null);
            }
        }

        public async Task<ProductResponse> DeleteProductAsync(int id)
        {
            var record = await repo.GetByIdAsync(id);
            if (record != null)
            {
                repo.Delete(record);
                await repo.SaveChangesAsync();
                return GetResponse(true, "Product deleted successfully", null);
            }
            else
            {
                return GetResponse(false, "Product not found", null);
            }
        }


        private ProductResponse GetResponse(bool isSuccess, string Message, List<Product>? Data)
        {
            return new ProductResponse
            {
                IsSuccess = isSuccess,
                Message = Message,
                Data = Data ?? []
            };
        }
    }
}