using KekaForum.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KekaForum.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService UserService;

        public UsersController(IUserService userService)
        {
            this.UserService = userService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await this.UserService.GetAllUsers();
            return Ok(result);
        }
    }
}
