using KekaForum.Services.Interfaces;
using KekaForum.Services.Models.Data;
using KekaForum.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KekaForum.Controllers
{
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private IAnswerService AnswerService;
        public AnswersController(IAnswerService answerService)
        {
            this.AnswerService = answerService;
        }

        // GET api/questions/5/answers
        [Route("api/questions/{questionId}/answers")]
        public async Task<IActionResult> GetAnswersByQuestionId(int questionId)
        {
            var result= await this.AnswerService.GetAnswersByQuestionId(questionId);
            return Ok(result);
        }

        // POST api/questions/2/answers
        [HttpPost]
        [Route("api/questions/{questionId}/answers")]
        public async Task<IActionResult> PostAnswer([FromBody] AnswerModel answer)
        {
            var result = await this.AnswerService.AddAnswer(answer);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
