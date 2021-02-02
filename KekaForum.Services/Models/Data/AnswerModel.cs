using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KekaForum.Services.Models.Data
{
    public class AnswerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string UserProfilePicUrl { get; set; }
        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        [Required]
        public int LikesCount { get; set; }
        [Required]
        public int DislikesCount { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public int IsBestAnswer { get; set; }
    }
}
