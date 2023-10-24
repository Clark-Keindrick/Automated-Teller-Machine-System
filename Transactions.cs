using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ATM_FINAL
{
    class Transactions
    {
        public string Acc_No { get; set; }
        public string Pin { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Cardtype { get; set; }
        public long Balance { get; set; }

        public long withdrawal { get; set; }
        public long deposit { get; set; }
        public int dep = 0, wid = 0, bal = 0;

        public Transactions(string acc_No, string pin, string firstname, string lastname, long balance, string cardtype)
        {
            Acc_No = acc_No;
            Pin = pin;
            Firstname = firstname;
            Lastname = lastname;
            Balance = balance;
            Cardtype = cardtype;
        }

        public void Deposit()
        {
            Console.WriteLine();
            Console.Clear();
            Console.Write("How much would you like to deposit? : ");
            deposit = Convert.ToInt64(Console.ReadLine());

            if (deposit % 20 != 0 && deposit % 50 != 0 && deposit > 0)
            {
                Console.WriteLine("\nSorry, We only accept paper bills");
            }
            else if (deposit < 0)
            {
                Console.WriteLine("\nSorry, Invalid Amount");
            }
            else
            {
                Balance = Balance + deposit;
            }
            Console.WriteLine("\nYOUR BALANCE IS: P" + Balance.ToString("F2"));
            dep += 1;
            Console.WriteLine();
        }

        public void Withdraw()
        {
            Console.WriteLine();
            Console.Clear();
            Console.Write("How much would you like to withdraw? : ");
            withdrawal = Convert.ToInt64(Console.ReadLine());

            if (withdrawal % 20 != 0 && withdrawal % 50 != 0 && withdrawal > 0)
            {
                Console.WriteLine("\nSorry, We can only release paper bills\n");
            }
            else if (withdrawal < 0)
            {
                Console.WriteLine("\nSorry, Invalid Amount\n");
            }
            else if (withdrawal > (Balance - 500))
            {
                Console.WriteLine("\nSorry, Insufficient Balance\n");
            }
            else
            {
                Balance = Balance - withdrawal;
                Console.WriteLine("\nPLEASE COLLECT CASH: P" + withdrawal.ToString("F2"));
                Console.WriteLine("\nYOUR CURRENT BALANCE IS: P " + Balance.ToString("F2"));
                wid += 1;
                Console.WriteLine();
            }
        }

        public void balance()
        {
            Console.Clear();
            Console.WriteLine("\nYOUR CURRENT BALANCE IS: P " + Balance.ToString("F2"));
            bal += 1;
            Console.WriteLine();
        }
    }
}
