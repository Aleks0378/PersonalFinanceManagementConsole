using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManagementConsole.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int LoginAttempts { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public decimal Balance { get; set; } = 0;
        public UserSettings? Settings { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
