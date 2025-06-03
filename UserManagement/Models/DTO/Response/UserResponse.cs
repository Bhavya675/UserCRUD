using UserManagement.Entities;

namespace UserManagement.DTO.Response
{
    public class UserResponse : BaseResponse
    {
        public List<User>? Data { get; set; }
    }
}