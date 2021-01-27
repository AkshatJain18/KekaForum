using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Interfaces
{
    public interface IQuestionService
    {
        public Task<IEnumerable<KekaForum.Models.Core.Question>> GetAllQuestions();
        public Task<KekaForum.Models.Core.Question> GetQuestionById(int id);
        public Task<bool> AddQuestion(KekaForum.Models.Core.Question questionDto);
    }
}
