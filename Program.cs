using System.Net.NetworkInformation;
using System.Security;
using System.Text;
using System.Transactions;
using ATM_FINAL;

namespace ATM_FINAL
{
    class Program
    {
        public static void Main()
        {
            char choice, choice2;

            Console.WriteLine();
            Console.Clear();
            Console.Write("Do you want to Log-in? Y-yes/ N - no: ");
            choice = char.Parse(Console.ReadLine());
            choice2 = char.ToUpper(choice);

            if (choice2 == 'Y')
            {
                Log_in();
            }
            else
            {
                Console.WriteLine("\nThanks for using our ATM Service, Have a nice day :)");
            }
        }

        public static void Log_in()
        {
            char choice, choice2;
            TimeSpan timeout = new TimeSpan(0, 0, 1);
            Options[] user = new Options[10];
            user[0] = new Options("Mollejon1818", "11082002", "Clark", "Mollejon", 2500, "Debit Card");
            user[1] = new Options("Cudiera2001", "1313364", "Merna May", "Cudiera", 50000, "Premium Card");
            user[2] = new Options("Belladsmol2023", "1313390", "Blessie", "Seno", 10000, "Debit Master Card");
            user[3] = new Options("Torreon7174", "1337856", "Johnny", "Sin", 41000, "Visa Debit Card");

            Console.Clear();
            Console.Write("\nACCOUNT NAME: ");
            string acc = Console.ReadLine();
            Console.Write("\nPin: ");

            StringBuilder pin = new StringBuilder();
            while (true)
            {
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && pin.Length > 0)
                {
                    pin.Remove(pin.Length - 1, 1);
                    Console.SetCursorPosition(x - 1, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x - 1, y);
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    pin.Append(key.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();

            for (int i = 0; i < user.Length; i++)
            {
                if (acc == user[i].Acc_No && pin.Equals(user[i].Pin))
                {
                    Console.Write("Log in Successful");
                    for (int k = 0; k < 5; k++)
                    {
                        Console.Write(".");

                        Thread.Sleep(timeout);
                    }
                    Console.Clear();
                    Console.WriteLine($"Welcome, {user[i].Firstname} :)");
                    Console.WriteLine();
                    user[i].Atm_Options();
                    Main();
                    user[i].receipt(acc);
                    break;
                }

                else if (i == 3 && acc != user[i].Acc_No && !pin.Equals(user[i].Pin))
                {
                    Console.Clear();
                    Console.WriteLine("Sorry Invalid Account\n");

                    Console.Write("Press any key to continue: ");
                    char x = Console.ReadKey().KeyChar;

                    Main();
                    break;
                }

                else if (acc == user[i].Acc_No || pin.Equals(user[i].Pin))
                {
                    Console.Clear();
                    Console.WriteLine("Sorry Invalid Account\n");

                    Console.Write("Press any key to continue: ");
                    char x = Console.ReadKey().KeyChar;

                    Main();
                    break;
                }
            }
        }
    }
}