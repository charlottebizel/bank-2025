using System;
using banque.Models;

namespace banque
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Person jean = new Person("Jean", "Dupont", new DateTime(1990, 5, 12));
            CurrentAccount ca = new CurrentAccount("001", jean, 500);
            SavingsAccount sa = new SavingsAccount("002", jean);

            Bank banque = new Bank("Banque Centrale");
            banque.AddAccount(ca);
            banque.AddAccount(sa);

            ca.Deposit(1000);
            ca.Withdraw(200);
            sa.Deposit(800);
            sa.Withdraw(150);

            Console.WriteLine("\n--- Application des intérêts ---");
            ca.ApplyInterest();
            sa.ApplyInterest();

            banque.DisplayAllAccounts();

            Console.WriteLine($"\n🍭 Solde total de {jean}: {banque.GetTotalBalance(jean):C}");
        }
    }
}
