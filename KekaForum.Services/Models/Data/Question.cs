using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KekaForum.Services.Models.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        [Required]
        public string UserProfilePicUrl { get; set; }
        [Required]
        public int UpvotesCount { get; set; }
        [Required]
        public int ViewsCount { get; set; }
        [Required]
        public int AnswersCount { get; set; }
        [Required]
        public int IsResolved { get; set; }
    }
}
