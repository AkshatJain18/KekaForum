using System;
using System.Collections.Generic;
using System.Text;

namespace KekaForum.Models.Core
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public DateTime DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Answer { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
    }
}
