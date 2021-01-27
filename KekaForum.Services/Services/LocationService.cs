using Dapper;
using KekaForum.Services.Interfaces;
using KekaForum.Services.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Services
{
    public class LocationService : ILocationService
    {
        IDbConnection SqlConnection;
        public LocationService(IKekaForumDbContext kekaForumDbContext)
        {
            this.SqlConnection = kekaForumDbContext.GetDbConnection();
        }

        public Task<Location> GetLocationById(int id)
        {
            string query = "select * from [Locations] where Id=@Id";
            return this.SqlConnection.QuerySingleOrDefaultAsync<Location>(query, new { Id = id });
        }
    }
}
