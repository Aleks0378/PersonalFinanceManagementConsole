using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagementConsole.Data;
using PersonalFinanceManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = PersonalFinanceManagementConsole.Model.Transaction;

namespace PersonalFinanceManagementConsole.Repository
{
    public class TransactionRepository : ITransaction
    {
        public async Task AddTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction> GetTransactionByIdWithCategory(int id)
        {
            using(ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByTimePeriodAsync(DateTime dateBegin, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByTypeAndCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(string type)
        {
            throw new NotImplementedException();
        }
    }
}
