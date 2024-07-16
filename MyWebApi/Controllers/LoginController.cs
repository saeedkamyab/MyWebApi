using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;
using MyWebApi.Repo.Interface;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogin _login;
        public LoginController(AppDbContext context, ILogin login)
        {
            _context = context;
            _login = login;
        }
        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] LoginViewModel loginModel)
        {
            var result = _login.Login(loginModel);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }


    }
}
