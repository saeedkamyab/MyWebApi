using Microsoft.IdentityModel.Tokens;
using MyWebApi.Models;
using MyWebApi.Repo.Interface;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebApi.Repo.Services
{
    public class LoginService : ILogin
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public string Login(LoginViewModel loginModel)
        {
            if (loginModel != null)
            {
                var user = _context.Users.Where(u => u.UserName == loginModel.UserName & u.Password == loginModel.Password);
                if (user.Count() > 0)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
                    var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOption = new JwtSecurityToken(
                        issuer: "https://localhost:7264",
                        claims: new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,loginModel.UserName),
                            new Claim(ClaimTypes.Role,"Admin")
                        },
                        expires:DateTime.Now.AddMinutes(30),
                        signingCredentials:signinCredential
                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                    return token;
                }
            }
            return null;
        }
    }
}
