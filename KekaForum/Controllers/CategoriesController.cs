using KekaForum.Models.Core;
using KekaForum.Services.Models.Data;
using KekaForum.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KekaForum.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService CategoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.CategoryService.GetAllCategories();
            return Ok(result);
        }

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Services.Models.Data.Category category)
        {
            var result = await this.CategoryService.AddCategory(category);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
