using MyWebApi.Models;
using MyWebApi.Repo.Interface;

namespace MyWebApi.Repo.Services
{
    public class LoginService : ILogin
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public bool Login(string userName, string pass)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(pass))
            {
                var user = _context.Users.Where(u => u.UserName == userName & u.Password == pass);
                if (user.Count() > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
