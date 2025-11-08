using System;
using System.Collections.Generic;
using System.Linq;

namespace banque
{
    public class Bank
    {
        public string Name { get; set; }
        public Dictionary<string, Account> Accounts { get; private set; } = new();

        public Bank(string name) => Name = name;

        public void AddAccount(Account account)
        {
            if (account == null || Accounts.ContainsKey(account.Number))
            {
                Console.WriteLine("🫗 Compte invalide ou déjà existant.");
                return;
            }
            Accounts[account.Number] = account;
            Console.WriteLine($"🎂 Compte {account.Number} ajouté à la banque {Name}.");
        }

        public void DeleteAccount(string number)
        {
            if (Accounts.Remove(number))
                Console.WriteLine($"🥕 Compte {number} supprimé.");
            else
                Console.WriteLine($"🥨 Le compte {number} n'existe pas.");
        }

        public double GetBalance(string number) =>
            Accounts.ContainsKey(number) ? Accounts[number].GetBalance() : 0;

        public double GetTotalBalance(Person owner) =>
            Accounts.Values.Where(a => a.Owner == owner).Sum(a => a.GetBalance());

        public void DisplayAllAccounts()
        {
            foreach (var acc in Accounts.Values)
                Console.WriteLine(acc);
        }
    }
}
