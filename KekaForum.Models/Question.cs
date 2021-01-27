using System;
using System.Collections.Generic;
using System.Text;

namespace KekaForum.Models.Core
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserProfilePicUrl { get; set; }
        public int UpvotesCount { get; set; }
        public int ViewsCount { get; set; }
        public int AnswersCount { get; set; }
        public Boolean IsResolved { get; set; }
    }
}
