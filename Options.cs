using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ATM_FINAL
{
    class Options : Transactions
    {
        public string Acc_No { get; set; }
        public string Pin { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long Balance { get; set; }
        public string Cardtype { get; set; }

        public Options(string acc_No, string pin, string firstname, string lastname, long balance, string cardtype) : base(acc_No, pin, firstname, lastname, balance, cardtype)
        {
            Acc_No = acc_No;
            Pin = pin;
            Firstname = firstname;
            Lastname = lastname;
            Balance = balance;
            Cardtype = cardtype;
        }

        public void Atm_Options()
        {
            int opt;
            Console.WriteLine("==========Welcome to CTMS Bank ATM Service :)===============\n");
            Console.WriteLine("1. Check Balance\n");
            Console.WriteLine("2. Withdraw Cash\n");
            Console.WriteLine("3. Deposit Cash\n");
            Console.WriteLine("4. Exit\n");
            Console.Write("***********************************************************\n\n");
            Console.Write("Enter your choice: ");
            opt = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                if (opt == 1)
                {
                    balance();

                    Console.Write("Press any key to continue: ");
                    char x = Console.ReadKey().KeyChar;

                    Console.Clear();
                    Atm_Options();
                    break;
                }
                else if (opt == 2)
                {
                    Withdraw();

                    Console.Write("Press any key to continue: ");
                    char x = Console.ReadKey().KeyChar;

                    Console.Clear();
                    Atm_Options();
                    break;
                }
                else if (opt == 3)
                {
                    Deposit();

                    Console.Write("Press any key to continue: ");
                    char x = Console.ReadKey().KeyChar;

                    Console.Clear();
                    Atm_Options();
                    break;
                }
                else if (opt == 4)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nSorry Invalid Input\n");

                    Console.Write("Press any key to continue: ");
                    char x = Console.ReadKey().KeyChar;

                    Console.Clear();
                    Atm_Options();
                    break;
                }
            }
        }

        public void receipt(string account)
        {
            string date = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            string time = "Time: " + DateTime.Now.ToString("hh:mm:ss");
            string fullpath = @"C:\Users\User\OneDrive\Programming 2\C# PROGRAMMING\ATM FINAL\ATM FINAL\ATMReceipt.txt";
            var randomInteger = new Random();


            using (StreamWriter writer = new StreamWriter(fullpath))
            {
                writer.WriteLine("\t     CTMS BANK ATM SERVICE\n");
                writer.Write(date + "\t\t");
                writer.WriteLine(time);
                if(wid == 1)
                {
                    writer.Write("\nTransaction: Cash Withdrawal\t");
                    writer.WriteLine("Amount: P" + withdrawal);
                    writer.Write("Current Balance: P" + (Balance - withdrawal));
                    writer.WriteLine("\t\tAvailable Balance: P" + (Balance - withdrawal));
                }
                else if(dep == 1)
                {
                    writer.Write("\nTransaction: Cash Deposit\t");
                    writer.WriteLine("Amount: P" + deposit);
                    writer.Write("Current Balance: P" + (Balance + deposit));
                    writer.WriteLine("\t\tAvailable Balance: P" + (Balance + deposit));
                }
                else if (bal == 1)
                {
                    writer.WriteLine("\nTransaction: Checking Balance\t");
                    writer.Write("Current Balance: P" + (Balance + deposit));
                    writer.WriteLine("\t\tAvailable Balance: P" + (Balance + deposit));
                }
                else
                {
                    writer.Write("\nTransaction: \t");
                    writer.WriteLine("Amount: ");
                    writer.Write("Current Balance: ");
                    writer.WriteLine("\t\tAvailable Balance: ");
                }

                string alph = "abcdefghijklmnopqrstuvwxyz";

                foreach (char i in alph)
                {
                    account = account.Replace(i, '*');
                }

                writer.Write("From " + account);
                writer.WriteLine("\t\t\tLocation: Gaisano Super Metro, Lapu-Lapu City ");
                writer.Write("Receipt No. " + randomInteger.Next());
                writer.WriteLine("\t\tApplication Label: " + Cardtype);
                writer.WriteLine("\n\nENJOY THE CONVENIENCE OF 24/7 BANKING.");
                writer.WriteLine("PAY YOUR BILLS VIA CTMS ATMS AND EARN CTMS REWARD POINTS");
                writer.WriteLine("VISIT ANY CTMS BRANCH TO KNOW MORE.");
            }
        }

    }
}
