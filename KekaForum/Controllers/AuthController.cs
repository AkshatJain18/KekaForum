using KekaForum.Models.Core;
using KekaForum.Services.Interfaces;
using KekaForum.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KekaForum.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService AuthService;
        public AuthController(IAuthService authService)
        {
            this.AuthService = authService;
        }

        // GET api/auth/login
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Get(Login login)
        {
            var result = await this.AuthService.Login(login);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // POST api/auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post([FromBody] Register register)
        {
            var result=await this.AuthService.Register(register);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
