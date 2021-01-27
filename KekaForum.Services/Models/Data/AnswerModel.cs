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
        public int UserId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public bool IsBestAnswer { get; set; }
    }
}
