using KekaForum.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById();
    }
}
