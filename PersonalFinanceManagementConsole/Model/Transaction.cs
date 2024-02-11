using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManagementConsole.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Type {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
    }
}
