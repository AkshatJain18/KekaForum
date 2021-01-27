using KekaForum.Services.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<Location> GetLocationById(int id);
    }
}
