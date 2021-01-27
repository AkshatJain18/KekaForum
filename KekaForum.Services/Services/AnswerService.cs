using AutoMapper;
using Dapper;
using KekaForum.Models.Core;
using KekaForum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using AnswerData=KekaForum.Services.Models.Data.AnswerModel;
using AnswerCore = KekaForum.Models.Core.AnswerModel;

namespace KekaForum.Services.Services
{
    public class AnswerService:IAnswerService
    {
        IDbConnection SqlConnection;
        IMapper Mapper;

        public AnswerService(IKekaForumDbContext kekaForumDbContext, IMapper mapper)
        {
            this.SqlConnection = kekaForumDbContext.GetDbConnection();
            this.Mapper = mapper;
        }

        public async Task<IEnumerable<AnswerCore>> GetAnswersByQuestionId(int questionId)
        {
            string query = "select [Users].ProfilePicUrl,[Users].FirstName,[Users].LastName" +
                "[Answers].Answer from,[Answers].IsBestAnswer," +
                "count(case when [Activites].ActivityType=@like then 1 end) as LikesCount," +
                "count(case when [Activites].ActivityType=@dislike then 1 end) as DislikesCount" +
                "from [Answers] inner join [Users]" +
                "on [Answers].UserId=[Users].Id and [Answers].QuestionId=@questionId order by [Answers].DateCreated";

            var answers = await this.SqlConnection.QueryAsync(query,new { like = (int)ActivityType.Like, dislike = (int)ActivityType.Dislike, questionId=questionId});
            return this.Mapper.Map<IEnumerable<AnswerCore>>(answers);
        }

        public async Task<bool> AddAnswer(AnswerData answerModel)
        {
            string query = "insert into [Answers] values (@Id,@QuestionId,@Answer,@UserId,@DateCreated,@IsBestAnswer";
            var result=await this.SqlConnection.ExecuteScalarAsync<bool>(query,answerModel);
            return result;
        }
    }
}
