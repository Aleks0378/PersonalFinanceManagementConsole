using PersonalFinanceManagementConsole.Interfaces;
using PersonalFinanceManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManagementConsole.Repository
{
    public class CategoryRepository : ICategory
    {
        public async Task AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
