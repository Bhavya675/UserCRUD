using UserManagement.Common;

namespace UserManagement.Models
{
    public class LoginResponse : BaseResponse
    {
        public string? Token { get; set; }
    }
}
