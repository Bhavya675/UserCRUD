using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.Entities;
using MinimalAPI.Models.DTO.Request;
using MinimalAPI.Models.DTO.Response;

namespace MinimalAPI.Services.Interface
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product?> GetProductByIdAsync(int id);
        public Task<ProductResponse> AddProductAsync(ProductDTO product);
        public Task<ProductResponse> UpdateProductAsync(int id, ProductDTO product);
        public Task<ProductResponse> DeleteProductAsync(int id);
    }
}