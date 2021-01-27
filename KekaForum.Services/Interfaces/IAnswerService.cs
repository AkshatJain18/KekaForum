using KekaForum.Models.Core;
using KekaForum.Services.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Interfaces
{
    public interface IAnswerService
    {
        public  Task<IEnumerable<KekaForum.Models.Core.AnswerModel>> GetAnswersByQuestionId(int questionId);
        public  Task<bool> AddAnswer(Models.Data.AnswerModel answerModel);
    }
}
