using RahmanyCourses.Core.Entities;
using RahmanyCourses.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RahmanyCourses.Infrastructure.Persistance.Services
{
    public class AuthService : IAuthService
    {
        IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreateHashPassword(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokens = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(double.Parse(_configuration["JWT:DurationInHours"])),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(tokens);
            return jwt;
        }

        public RefreshToken CreateRefreshToken()
        {
            var random = new byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(random);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(random),
                ExpiredOn = DateTime.UtcNow.AddHours(10),
                CreatedOn = DateTime.UtcNow
            };
        }
        
        public bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordsalt)
        {
            using(var hmac = new HMACSHA512(passwordsalt))
            {
                var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedhash.AsSpan().SequenceEqual(passwordhash);
            }
        }


        public string DcryptPassword(string encryptedText)
        {
            string decryptedText = "";
            using (var _privateKey = RSA.Create(2048))
            {                              
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedBytes = _privateKey.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
                decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            }
            return decryptedText;
        }
    }
}
