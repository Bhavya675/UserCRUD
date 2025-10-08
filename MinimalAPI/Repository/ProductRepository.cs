using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;
using MinimalAPI.Repository.Interface;

namespace MinimalAPI.Repository
{
    public class ProductRepository(ProductDbContext dbContext) : IProductRepository
    {
        public async Task<List<Product>> GetAllAsync() => await dbContext.Products.ToListAsync();
        public async Task<Product?> GetByIdAsync(int id) => await dbContext.Products.FindAsync(id);
        public async Task AddAsync(Product product) => await dbContext.Products.AddAsync(product);
        public async Task<bool> NameExistsAsync(string name) => await dbContext.Products.AnyAsync(x => x.Name == name);
        public void Update(Product product) => dbContext.Products.Update(product);
        public void Delete(Product product) => dbContext.Products.Remove(product);
        public async Task<bool> SaveChangesAsync() => await dbContext.SaveChangesAsync() > 0;
    }
}