using System;

namespace BankAccount
{
    class Program
    {
        public static event Operation Message;
        static void Main()
        {
            int money = 2000;
            Bank account = new Bank(money);
            account.BalansInfo();
            account.AccountEvent += Info;
            Message += Console.WriteLine;
            Message?.Invoke("Введите сумму которую хотите внести рублей ");
            money = Convert.ToInt32(Console.ReadLine());
            account.InsertMoney(money);
            Message?.Invoke("Введите сумму которую хотите снять рублей ");
            money = Convert.ToInt32(Console.ReadLine());
            account.TakeMoney(money);
        }
        public static void Info(string info)
        {
            Console.WriteLine(info);
        }
    }    
}
