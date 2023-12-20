using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Enums;
using System.Text.Json.Serialization;

namespace RahmanyCourses.Persentation.Models
{
    public class UserResponseModel
    {
        public string Username { get; set; }        
        public string Token { get; set; }
        public UserType UserType { get; set; }
        [JsonIgnore]
        public string RefreshToken{ get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
