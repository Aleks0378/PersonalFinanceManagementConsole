using PersonalFinanceManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManagementConsole.Interfaces
{
    public interface IUser
    {
        Task<User> GetUserAsync(int id); 
        Task<User> GetUserByNameAsync(string name);
        Task<User> GetUserWithTransactionsAsync(int id);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
