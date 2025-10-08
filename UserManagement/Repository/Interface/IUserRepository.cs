using System.Linq.Expressions;
using UserManagement.Entities;

namespace UserManagement.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
        Task<User?> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate);
        void Update(User user);
        void Delete(User user);
        Task<bool> SaveChangesAsync();
    }
}