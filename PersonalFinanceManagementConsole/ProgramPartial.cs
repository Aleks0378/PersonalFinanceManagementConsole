using PersonalFinanceManagementConsole.Helpers;
using PersonalFinanceManagementConsole.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PersonalFinanceManagementConsole
{
    public partial class Program
    {
        #region User
        static async Task ReviewUserBalance(int Id)
        {
            var currentUser = await _user.GetUserAsync(Id);
            Console.WriteLine($"\n\nCurrent Ballance: {currentUser.Balance}");
        }
        static async Task BrowseUserTransactions(int Id)
        {
            var UserWithTransactions = await _user.GetUserWithTransactionsAsync(Id);
            if (UserWithTransactions is not null)
            {
                if (UserWithTransactions.Transactions.Count > 0)
                {
                    await ReviewTransactions(UserWithTransactions.Transactions);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No transactions were found.");
                }
            }
            else
            {
                Console.WriteLine("The User could not be found.");
            }
        }
        #endregion
        #region Transactions
        static async Task ReviewTransactions(ICollection<Model.Transaction>? userTransactions = null)
        {
            if (userTransactions.Any()) 
            {
                var transacts = userTransactions.Select(e => new ItemView { Id = e.Id, Value = e.Name }).ToList();
                int result = ItemsHelper.MultipleChoice(true, transacts, true);
                if (result != 0)
                {
                    var currentTransact = await _transactions.GetTransactionByIdWithCategory(result);
                    //await BookInfo(currentBook);
                }
            }
            
        }
        #endregion
    }
}
