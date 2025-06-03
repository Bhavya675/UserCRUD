using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MinimalAPI.Entities;

namespace MinimalAPI.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
        void Update(User user);
        void Delete(User user);
        Task<bool> SaveChangesAsync();
    }
}