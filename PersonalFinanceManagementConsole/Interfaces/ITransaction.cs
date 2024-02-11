using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PersonalFinanceManagementConsole.Model;

namespace PersonalFinanceManagementConsole.Interfaces
{
    public interface ITransaction
    {
        Task AddTransactionAsync(Model.Transaction transaction);
        Task<Model.Transaction> GetTransactionByIdWithCategory(int Id);
        Task<IEnumerable<Model.Transaction>> GetAllTransactionsAsync();
        Task<IEnumerable<Model.Transaction>> GetTransactionsByTypeAsync(string type);
        Task<IEnumerable<Model.Transaction>> GetTransactionsByTimePeriodAsync(DateTime dateBegin, DateTime dateEnd);
        Task<IEnumerable<Model.Transaction>> GetTransactionsByTypeAndCategoryAsync();
    }
}
