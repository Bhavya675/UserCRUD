using UserManagement.Entities;
using UserManagement.Models;

namespace UserManagement.Interfaces;

public interface IUserService
{
    Task<List<UserResponseDTO>> GetAllUsersAsync();
    Task<UserResponseDTO?> GetUserByIdAsync(int id);
    Task<UserResponse> AddUserAsync(UserDTO requestObject);
    Task<UserResponse> UpdateUserAsync(int id, UserDTO requestObject);
    Task<UserResponse> DeleteUserAsync(int id);

    Task<LoginResponse> Login(LoginRequestDTO requestObject);

    Task<UserResponse> ChangePasswordAsync(int id, ChangePassword requestObject);
}
