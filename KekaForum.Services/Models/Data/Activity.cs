using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KekaForum.Services.Models.Data
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public Int16 ActivityType { get; set; }
    }
}
