using Core.Entities;
using Core.Enums;
using System.Text.Json.Serialization;

namespace RahmanyCourses.Response
{
    public class UserResponse
    {
        public string Username { get; set; }        
        public string Token { get; set; }
        public UserType UserType { get; set; }
        [JsonIgnore]
        public string RefreshToken{ get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
