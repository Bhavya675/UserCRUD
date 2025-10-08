using UserManagement.Common;

namespace UserManagement.Models
{
    public class UserResponse : BaseResponse
    {
        public List<UserResponseDTO>? Data { get; set; }
    }
}