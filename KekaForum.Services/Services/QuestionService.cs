using KekaForum.Services.Interfaces;
using KekaForum.Models.Core;
using KekaForum.Services.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AutoMapper;
using Dapper;
using System.Threading.Tasks;

namespace KekaForum.Services.Services
{
    public class QuestionService:IQuestionService
    {
        IDbConnection SqlConnection;
        IMapper Mapper;

        public QuestionService(IKekaForumDbContext kekaForumDbContext,IMapper mapper)
        {
            this.SqlConnection = kekaForumDbContext.GetDbConnection();
            this.Mapper = mapper;
        }

        public async Task<IEnumerable<KekaForum.Models.Core.Question>> GetAllQuestions()
        {
            string query = "select [Questions].Id,[Questions].Title,[Questions].Description," +
                "[AspNetUsers].FirstName,[AspNetUsers].ProfilePicUrl," +
                "count(case when [Activities].ActivityType = @upvote then 1 end) as 'UpvotesCount'," +
                "count(case when [Activities].ActivityType = @view then 1 end) as 'ViewsCount'," +
                "count([Answers].Id) as 'AnswersCount',[Questions].IsResolved" +
                "from [Questions] inner join [AspNetUsers] on [Questions].UserId =  [AspNetUsers].Id " +
                "left outer join [Answers] on [Questions].Id =[Answers].QuestionId " +
                "left outer join [Activities] on [Questions].Id = [Activities].QuestionId " +
                "group by [Questions].Id,[Questions].Title,[Questions].Description," +
                "[AspNetUsers].ProfilePicUrl,[AspNetUsers].FirstName";

            var result = await this.SqlConnection.QueryAsync(query,
                new { upvote = (int)ActivityType.Upvote, view = (int)ActivityType.View });

            return this.Mapper.Map<IEnumerable<KekaForum.Models.Core.Question>>(result);
        }

        public async Task<KekaForum.Models.Core.Question> GetQuestionById(int id)
        {
            string query = "select [Questions].Id,[Questions].Title,[Questions].Description," +
                "[AspNetUsers].FirstName,[AspNetUsers].ProfilePicUrl," +
                "count(case when [Activities].ActivityType = @upvote then 1 end) as 'UpvotesCount'," +
                "count(case when [Activities].ActivityType = @view then 1 end) as 'ViewsCount'," +
                "count([Answers].Id) as 'AnswersCount',[Questions].IsResolved" +
                "from [Questions] inner join [AspNetUsers] on [Questions].UserId =  [AspNetUsers].Id " +
                "and [Questions].Id=@id" +
                "left outer join [Answers] on [Questions].Id =[Answers].QuestionId " +
                "left outer join [Activities] on [Questions].Id = [Activities].QuestionId " +
                "group by [Questions].Id,[Questions].Title,[Questions].Description," +
                "[AspNetUsers].ProfilePicUrl,[AspNetUsers].FirstName";
            
            var result= await this.SqlConnection.QueryAsync<KekaForum.Models.Core.Question>(query, 
                new { id = id, upvote = (int)ActivityType.Upvote, view = (int)ActivityType.View });

            return this.Mapper.Map<KekaForum.Models.Core.Question>(result);
        }

        public async Task<IEnumerable<KekaForum.Models.Core.Question>> GetQuestionByUserId(int userId)
        {
            string query = "select [Questions].Id,[Questions].Title,[Questions].Description," +
                "[AspNetUsers].FirstName as 'UserFirstName',[AspNetUsers].ProfilePicUrl as 'UserProfilePicUrl'," +
                "count(case when [Activities].ActivityType = @upvote then 1 end) as 'UpvotesCount'," +
                "count(case when [Activities].ActivityType = @view then 1 end) as 'ViewsCount'," +
                "count([Answers].Id) as 'AnswersCount',[Questions].IsResolved" +
                "from [Questions] inner join [AspNetUsers] on [Questions].UserId = @userId" +
                "left outer join [Answers] on [Questions].Id =[Answers].QuestionId " +
                "left outer join [Activities] on [Questions].Id = [Activities].QuestionId " +
                "group by [Questions].Id,[Questions].Title,[Questions].Description," +
                "[AspNetUsers].ProfilePicUrl,[AspNetUsers].FirstName";

            var result = await this.SqlConnection.QueryAsync<KekaForum.Models.Core.Question>(query, 
                new { userId = userId, upvote = (int)ActivityType.Upvote, view = (int)ActivityType.View });

            return this.Mapper.Map<IEnumerable<KekaForum.Models.Core.Question>>(result);
        }
        public async Task<bool> AddQuestion(KekaForum.Models.Core.Question questionDto)
        {
            Models.Data.Question question = this.Mapper.Map<Models.Data.Question>(questionDto);

            string query = "insert into [Questions]" +
                "([Title],[Description],[CategoryId],[UserId],[DateCreated],[IsResolved]) " +
                "output Inserted.ID " +
                "values (@Title,@Description,@CategoryId,@UserId,@DateCreated,@IsResolved)";

            var result = await this.SqlConnection.ExecuteScalarAsync(query, question);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
