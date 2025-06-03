using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.DTO.Response;
using MinimalAPI.Entities;
using MinimalAPI.Models.DTO.Request;

namespace MinimalAPI.Services.Interface
{
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
}