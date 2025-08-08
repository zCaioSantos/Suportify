using Microsoft.IdentityModel.Tokens;
using Suportify.Common.CrossCutting;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Suportify.Common.Utils
{
    public class CryptographyUtil
    {
        public static string EncryptToSha256(string text)
        {
            var crypt = SHA256.Create();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }


        public static string GenerateJwtToken(string id, string email, string nome)
        {
            DateTime value = DateTime.Now.AddSeconds(21600);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ProjectConfig.AppSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);


            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Thumbprint, id),
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = value,
                SigningCredentials = creds,
            };


            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(token);
        }

    }
}
