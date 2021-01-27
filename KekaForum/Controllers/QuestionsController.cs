using KekaForum.Models.Core;
using KekaForum.Services.Interfaces;
using KekaForum.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KekaForum.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionService QuestionService;
        public QuestionsController(IQuestionService questionService)
        {
            this.QuestionService = questionService;
        }

        // POST api/questions
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions(Login login)
        {
            var result = await this.QuestionService.GetAllQuestions();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // POST api/questions/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var result = await this.QuestionService.GetQuestionById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST api/questions
        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] Question question)
        {
            bool res= await this.QuestionService.AddQuestion(question);
            if (res)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
