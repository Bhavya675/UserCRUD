using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;

namespace MinimalAPI.Repository
{
    public class UserRepository(UserDbContext dbContext) : IUserRepository
    {

        public async Task<List<User>> GetAllAsync() => await dbContext.Users.AsNoTracking().ToListAsync();

        public async Task<User?> GetByIdAsync(int id) => await dbContext.Users.FindAsync(id);

        public async Task AddAsync(User user) => await dbContext.Users.AddAsync(user);

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate) => await dbContext.Users.AnyAsync(predicate);

        public void Update(User user) => dbContext.Users.Update(user);

        public void Delete(User user) => dbContext.Users.Remove(user);

        public async Task<bool> SaveChangesAsync() => await dbContext.SaveChangesAsync() > 0;
    }
}