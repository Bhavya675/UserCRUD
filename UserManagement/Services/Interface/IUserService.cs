// using UserManagement.DTO;
using UserManagement.DTO;
using UserManagement.DTO.Response;
using UserManagement.Entities;
using UserManagement.Models.DTO.Request;

namespace UserManagement.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<UserResponse> AddUserAsync(User requestObject);
    Task<UserResponse> UpdateUserAsync(int id, User requestObject);
    Task<UserResponse> DeleteUserAsync(int id);

    Task<LoginResponse> Login(LoginRequestDTO requestObject);

    Task<UserResponse> ChangePasswordAsync(int id, ChangePassword requestObject);
}
