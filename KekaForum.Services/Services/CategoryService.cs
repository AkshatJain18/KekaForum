using AutoMapper;
using Dapper;
using KekaForum.Models.Core;
using KekaForum.Services.Models.Data;
using KekaForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Services
{
    public class CategoryService:ICategoryService
    {
        IDbConnection SqlConnection;
        IMapper Mapper;

        public CategoryService(IKekaForumDbContext kekaForumDbContext, IMapper mapper)
        {
            this.SqlConnection = kekaForumDbContext.GetDbConnection();
            this.Mapper = mapper;
        }

        public async Task<IEnumerable<KekaForum.Models.Core.Category>> GetAllCategories()
        {
            string query = "select[Categories].Name,[Categories].Description,count(case when[Questions].CategoryId =[Categories].Id then 1 end) as 'TotalQuestions'," +
                "count(case when[Questions].CategoryId =[Categories].Id and[Questions].DateCreated >= DATEADD(DAY, -5, GETDATE()) then 1 end) as 'WeeklyTagCount'," +
                "count(case when[Questions].CategoryId =[Categories].Id and[Questions].DateCreated >= DATEADD(MONTH, -1, GETDATE()) then 1 end) as 'MonthlyTagCount' " +
                "from [Categories] left outer join [Questions] on [Categories].Id =[Questions].Id group by [Categories].Name,[Categories].Description";

            var result = await this.SqlConnection.QueryAsync<Models.Data.Category>(query);

            return this.Mapper.Map<IEnumerable<KekaForum.Models.Core.Category>>(result);
        }

        public async Task<bool> AddCategory(Models.Data.Category category)
        {
            string query = "insert into [Categories] values(@Id,@Name,@Description)";
            var result = await this.SqlConnection.ExecuteScalarAsync<bool>(query,category);
            return result;
        }
    }
}
