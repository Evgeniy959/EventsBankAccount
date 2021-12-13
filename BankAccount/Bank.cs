using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public delegate void Operation(string info);
    class Bank
    {
        public event Operation AccountEvent;
        public int Money { get; private set; }

        public Bank(int money)
        {
            Money = money;
        }

        public void BalansInfo()
        {
            Console.WriteLine($"На вашем счету {Money} рублей");
        }

        public void InsertMoney(int money)
        {
            Money += money;
            Console.ForegroundColor = ConsoleColor.Green;
            AccountEvent?.Invoke($"* На счет поступило {money} рублей ");
            Console.ResetColor();
            BalansInfo();
        }

        public void TakeMoney(int money)
        {
            if (Money >= money)
            {
                Money -= money;
                Console.ForegroundColor = ConsoleColor.Green;
                AccountEvent?.Invoke($"* Со счета снято {money} рублей ");
                Console.ResetColor();
                BalansInfo();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                AccountEvent?.Invoke("* На вашем счете недостаточно средств");
                Console.ResetColor();
                BalansInfo();
            }
        }
    }
}
