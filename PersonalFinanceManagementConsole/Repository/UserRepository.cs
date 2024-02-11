using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagementConsole.Data;
using PersonalFinanceManagementConsole.Helpers;
using PersonalFinanceManagementConsole.Interfaces;
using PersonalFinanceManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManagementConsole.Repository
{
    public class UserRepository : IUser
    {
        public bool RegisteredUser(string userName, string password)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                if (context.Users.Any(e => e.UserName == userName))
                {
                    Console.WriteLine("User with this username already exists!");
                    return false;
                }
                string salt = SecurityHelper.GenerateSalt(10101);
                string hashedPassword = SecurityHelper.HashPassword(password, salt, 10101, 70);
                context.Users.Add(new User
                {
                    UserName = userName,
                    Salt = salt,
                    PasswordHash = hashedPassword
                });
                context.SaveChanges();
                return true;
            }
             
        }
        public int AuthorizeUser(string userName, string password)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                var currentUser = context.Users.FirstOrDefault(e => e.UserName.Equals(userName));
                if (currentUser != null && !currentUser.IsLocked)
                {
                    string hashedPassword = SecurityHelper.HashPassword(password, currentUser.Salt, 10101, 70);
                    if (hashedPassword.Equals(currentUser.PasswordHash))
                    {
                        currentUser.LoginAttempts = 0;
                        context.SaveChanges();
                        return currentUser.Id;
                    }
                    else
                    {
                        currentUser.LoginAttempts++;
                        if (currentUser.LoginAttempts >= 3)
                            currentUser.IsLocked = true;
                        context.SaveChanges();
                        return -1;
                    }

                }
                return -1;
            }

        }

        public async Task AddUserAsync(User user)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.FirstOrDefaultAsync(e => e.UserName.Contains(name));
            }
        }

        public async Task<User> GetUserWithTransactionsAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
