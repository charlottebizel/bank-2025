using System;
using System.Collections.Generic;

namespace banque
{
    public class Bank
    {
        public string Name { get; set; }
        public Dictionary<string, CurrentAccount> Accounts { get; private set; }

        public Bank(string name)
        {
            Name = name;
            Accounts = new Dictionary<string, CurrentAccount>();
        }

        public void AddAccount(CurrentAccount account)
        {
            if (Accounts.ContainsKey(account.Number))
            {
                Console.WriteLine("⚠️ Un compte avec ce numéro existe déjà !");
                return;
            }

            Accounts.Add(account.Number, account);
            Console.WriteLine($"✅ Compte {account.Number} ajouté à la banque {Name}.");
        }

        public void DeleteAccount(string number)
        {
            if (Accounts.Remove(number))
                Console.WriteLine($" Compte {number} supprimé.");
            else
                Console.WriteLine($"Aucun compte trouvé avec le numéro {number}.");
        }

        public double GetBalance(string number)
        {
            if (Accounts.TryGetValue(number, out CurrentAccount account))
                return account.Balance;

            Console.WriteLine(" Compte introuvable !");
            return 0;
        }

        public double GetTotalBalance(Person person)
        {
            double total = 0;
            foreach (var acc in Accounts.Values)
            {
                if (acc.Owner == person)
                    total += acc.Balance;
            }
            return total;
        }
    }
}
