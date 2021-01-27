using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KekaForum.Models.Core;
using KekaForum.Services.Models.Data;
using KekaForum.Models;

namespace KekaForum.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<KekaForum.Models.Core.User> Login(Login login);
        public Task<KekaForum.Models.Core.User> Register(Register registerModel);
    }
}
