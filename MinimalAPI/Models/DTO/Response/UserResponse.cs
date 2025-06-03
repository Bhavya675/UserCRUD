using MinimalAPI.Entities;

namespace MinimalAPI.DTO.Response
{
    public class UserResponse : BaseResponse
    {
        public List<User>? Data { get; set; }
    }
}