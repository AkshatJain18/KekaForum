using Dapper;
using KekaForum.Services.DbContexts;
using KekaForum.Services.Interfaces;
using KekaForum.Services.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        IDbConnection SqlConnection;
        public DepartmentService(IKekaForumDbContext kekaForumDbContext)
        {
            this.SqlConnection = kekaForumDbContext.GetDbConnection();
        }
        public Task<Department> GetDepartmentById(int id)
        {
            string query = "select * from [Departments] where Id=@Id";
            return this.SqlConnection.QuerySingleOrDefaultAsync<Department>(query,new {Id = id});
        }
    }
}
