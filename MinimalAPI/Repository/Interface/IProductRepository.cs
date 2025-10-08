using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.Entities;

namespace MinimalAPI.Repository.Interface
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product?> GetByIdAsync(int id);
        public Task AddAsync(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public Task<bool> NameExistsAsync(string name);
        public Task<bool> SaveChangesAsync();
    }
}