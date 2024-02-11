using PersonalFinanceManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManagementConsole.Interfaces
{
    internal interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name);
        Task<Category> GetCategoryAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);

    }
}
