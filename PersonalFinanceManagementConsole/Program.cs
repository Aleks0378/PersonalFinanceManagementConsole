using PersonalFinanceManagementConsole.Data;
using PersonalFinanceManagementConsole.Helpers;
using PersonalFinanceManagementConsole.Interfaces;
using PersonalFinanceManagementConsole.Migrations;
using PersonalFinanceManagementConsole.Repository;

namespace PersonalFinanceManagementConsole
{
    partial class Program
    {
        enum LoginMenu
        { 
            Register, Login, Exit
        }

        enum UserMenu
        {
            CurrentBalance, AllTransactions, Incomes, Expenses, AddTransactions, Categories, Exit
        }


        private static IUser _user;
        private static ITransaction _transactions;
        private static ICategory _categories;

        public static ApplicationContext DbContext() => new ApplicationContextFactory().CreateDbContext();
        static async Task Main()
        {
            Initialize();
            await EntranceMenu();
            
        }

        private static async Task EntranceMenu()
        {
            int input = new int();
            
            using (ApplicationContext db = DbContext())
            {
                var userService = new UserRepository();
                bool a = true;
                while (a == true)
                {

                    input = ConsoleHelper.MultipleChoice(true, new LoginMenu());
                    switch ((LoginMenu)input)
                    {
                        case LoginMenu.Register:
                            {
                                Console.Write("\nEnter userName: ");
                                string userName = Console.ReadLine();
                                Console.Write("Enter password: ");
                                string password = Console.ReadLine();

                                if (userService.RegisteredUser(userName, password))
                                    Console.WriteLine("The User has been successfully registered!");
                                else
                                    Console.WriteLine("Error!");
                                break;
                            }
                        case LoginMenu.Login:
                            {
                                Console.Write("\nEnter userName: ");
                                string? userName = Console.ReadLine();
                                Console.Write("Enter password: ");
                                string? password = Console.ReadLine();
                                int currentUserId = userService.AuthorizeUser(userName, password);
                                if (currentUserId>0)
                                    await Menu(currentUserId);
                                else
                                {
                                    var currentUser = db.Users.FirstOrDefault(e => e.UserName.Equals(userName));
                                    if (currentUser != null)
                                        if (currentUser.IsLocked)
                                            Console.WriteLine("The user has been blocked!");
                                        else
                                            Console.WriteLine($"Wrong password! Remained attempts:{3 - currentUser.LoginAttempts}");
                                    else
                                        Console.WriteLine("The userName does not exist!");
                                }

                                break;
                            }
                        case LoginMenu.Exit:
                            {
                                a = false;
                                break;
                            }
                        default:
                            Console.WriteLine("Not valid input");
                            break;
                    }
                }
            }
        }

        private static async Task Menu(int userId)
        {
            int input = new int();
            do
            {
                input = ConsoleHelper.MultipleChoice(true, new UserMenu());
                switch ((UserMenu)input)
                {
                    case UserMenu.CurrentBalance:
                        await ReviewUserBalance(userId);
                        break;
                    case UserMenu.AllTransactions:
                        await BrowseUserTransactions(userId);
                        break;
                    case UserMenu.Incomes:
                        
                        break;
                    case UserMenu.Expenses:

                        break;
                    case UserMenu.AddTransactions:
                        
                        break;
                    case UserMenu.Categories:
                        
                        break;
                    case UserMenu.Exit:
                        await Main();
                        break;

                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            } while (true);
        }

        static void Initialize()
        {
            //new DbInit().Init(DbContext());
            _user = new UserRepository();
            _transactions = new TransactionRepository();
            _categories=new CategoryRepository();

        }
    }
}
