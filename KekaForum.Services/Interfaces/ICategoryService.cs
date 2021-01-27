using KekaForum.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<bool> AddCategory(Models.Data.Category category);
    }
}
