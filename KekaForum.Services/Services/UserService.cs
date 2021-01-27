using AutoMapper;
using Dapper;
using KekaForum.Models.Core;
using KekaForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Services
{
    public class UserService : IUserService
    {
        IDbConnection SqlConnection;
        IMapper Mapper;

        public UserService(IKekaForumDbContext kekaForumDbContext, IMapper mapper)
        {
            this.SqlConnection = kekaForumDbContext.GetDbConnection();
            this.Mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            string query = "select [Users].FirstName,[Users].LastName,[Users].Designation," +
                "[Departments].Name,[Locations].City from [Users],count(case when [Activites].ActivityType=@like then 1 end) as 'LikesCount'," +
                "count(case when [Activites].ActivityType=@dislike then 1 end) as 'DislikesCount' " +
                "from [Users] inner join [Departments]";

            return await this.SqlConnection.QueryAsync<User>(query);
        }

        public Task<User> GetUserById()
        {
            throw new NotImplementedException();
        }
    }
}
