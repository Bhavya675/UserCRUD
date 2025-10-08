using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Entities;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Repository;

namespace UserManagement.Services;

public class UserService(IUserRepository repo, IConfiguration _config, IMapper _mapper) : IUserService
{
    public async Task<List<UserResponseDTO>> GetAllUsersAsync() => _mapper.Map<List<UserResponseDTO>>(await repo.GetAllAsync());

    public async Task<UserResponseDTO?> GetUserByIdAsync(int id) => _mapper.Map<UserResponseDTO>(await repo.GetByIdAsync(id));

    public async Task<UserResponse> AddUserAsync(UserDTO requestObject)
    {
        try
        {
            var isDuplicate = await repo.AnyAsync(x => x.Email == requestObject.Email);

            if (isDuplicate)
            {
                return GetResponse(false, "User with this email already exists", null);
            }

            var request = _mapper.Map<User>(requestObject);
            await repo.AddAsync(request);
            await repo.SaveChangesAsync();

            var response = _mapper.Map<UserResponseDTO>(request);
            return GetResponse(true, "User created successfully.", new List<UserResponseDTO> { response });
        }
        catch (Exception ex)
        {
            return GetResponse(false, $"An error occurred while creating the user: {ex.Message}", null);
        }
    }

    public async Task<UserResponse> UpdateUserAsync(int id, UserDTO requestObject)
    {
        var record = await repo.GetByIdAsync(id);

        if (record != null && record.Username != requestObject.Username)
        {
            bool usernameTaken = await repo.AnyAsync(u => u.Username == requestObject.Username && u.Id != id);
            if (usernameTaken)
            {
                return GetResponse(false, "Username is already taken by another user", null);
            }
        }

        if (record != null)
        {
            _mapper.Map(requestObject, record);

            repo.Update(record);
            await repo.SaveChangesAsync();

            var response = _mapper.Map<UserResponseDTO>(record);
            return GetResponse(true, "User updated successfully", new List<UserResponseDTO> { response });
        }
        else
        {
            return GetResponse(false, "User Not Found", null);
        }
    }

    public async Task<UserResponse> DeleteUserAsync(int id)
    {
        var record = await repo.GetByIdAsync(id);
        if (record != null)
        {
            repo.Delete(record);
            await repo.SaveChangesAsync();
            return GetResponse(true, "User deleted successfully", null);
        }
        else
        {
            return GetResponse(false, "User not found", null);
        }
    }

    public async Task<LoginResponse> Login(LoginRequestDTO requestObject)
    {
        var users = await repo.GetAllAsync();
        var validEmail = await repo.AnyAsync(x => x.Email == requestObject.Email);
        if (validEmail)
        {
            var user = await repo.FirstOrDefaultAsync(x => x.Email == requestObject.Email && x.Password == requestObject.Password);
            if (user != null)
            {
                // JWT
                var token = GenerateJwtToken(user.Username, user.Role);
                return new LoginResponse
                {
                    IsSuccess = true,
                    Token = token,
                    Message = "Login Successful"
                };
            }
            else
            {
                return new LoginResponse
                {
                    IsSuccess = false,
                    Message = "Invalid Credentials"
                };
            }
        }
        else
        {
            return new LoginResponse
            {
                IsSuccess = false,
                Message = "Please register first to login"
            };
        }
    }

    public async Task<UserResponse> ChangePasswordAsync(int id, ChangePassword requestObject)
    {
        var record = await repo.GetByIdAsync(id);
        if (record != null)
        {
            if (record.Password != requestObject.OldPassword)
            {
                return GetResponse(false, "Incorrect old password", null);
            }
            else
            {

                // _mapper.Map(requestObject, record);
                repo.Update(record);
                return GetResponse(true, "Password changed successfully", null);
            }
        }
        else
        {
            return GetResponse(false, "User not found", null);
        }
    }

    private string GenerateJwtToken(string username, string role)
    {
        var jwt = _config.GetSection("Jwt");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(jwt["DurationInMinutes"])),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserResponse GetResponse(bool isSuccess, string Message, List<UserResponseDTO>? Data)
    {
        return new UserResponse
        {
            IsSuccess = isSuccess,
            Message = Message,
            Data = Data ?? []
        };
    }
}

