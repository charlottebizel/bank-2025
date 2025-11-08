using System;
using System.Collections.Generic;
using System.Linq;
using banque.Models;

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
                throw new ArgumentException("Compte invalide ou déjà existant.");

            Accounts[account.Number] = account;
            Console.WriteLine($"🎂 Compte {account.Number} ajouté à la banque {Name}.");
        }

        public void DeleteAccount(string number)
        {
            if (!Accounts.Remove(number))
                Console.WriteLine($"🥨 Le compte {number} n'existe pas.");
            else
                Console.WriteLine($"🥕 Compte {number} supprimé.");
        }

        public double GetBalance(string number) =>
            Accounts.ContainsKey(number) ? Accounts[number].Balance : 0;

        public double GetTotalBalance(Person owner) =>
            Accounts.Values.Where(a => a.Owner == owner).Sum(a => a.Balance);

        public void DisplayAllAccounts()
        {
            foreach (var acc in Accounts.Values)
                Console.WriteLine(acc);
        }
    }
}
