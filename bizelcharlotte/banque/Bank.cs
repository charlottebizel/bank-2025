using System;
using System.Collections.Generic;
using System.Linq;

namespace banque
{
    public class Bank
    {
        // Propriétés
        public string Name { get; set; }
        public Dictionary<string, Account> Accounts { get; private set; }

        // Constructeur
        public Bank(string name)
        {
            Name = name;
            Accounts = new Dictionary<string, Account>();
        }

        // Ajouter un compte
        public void AddAccount(Account account)
        {
            if (account == null)
            {
                Console.WriteLine(" Compte invalide.");
                return;
            }

            if (Accounts.ContainsKey(account.Number))
            {
                Console.WriteLine($" Le compte {account.Number} existe déjà.");
                return;
            }

            Accounts.Add(account.Number, account);
            Console.WriteLine($" Compte {account.Number} ajouté.");
        }

        // Supprimer un compte
        public void DeleteAccount(string number)
        {
            if (!Accounts.ContainsKey(number))
            {
                Console.WriteLine($" Le compte {number} n'existe pas.");
                return;
            }

            Accounts.Remove(number);
            Console.WriteLine($" Compte {number} supprimé.");
        }

        // Obtenir le solde d'un compte
        public double GetBalance(string number)
        {
            if (!Accounts.ContainsKey(number))
            {
                Console.WriteLine($" Le compte {number} n'existe pas.");
                return 0;
            }

            return Accounts[number].GetBalance();
        }

        // Somme de tous les comptes d'une personne
        public double GetTotalBalance(Person owner)
        {
            return Accounts.Values
                           .Where(a => a.Owner == owner)
                           .Sum(a => a.GetBalance());
        }

        // Afficher tous les comptes (facultatif)
        public void DisplayAllAccounts()
        {
            foreach (var account in Accounts.Values)
            {
                Console.WriteLine(account);
            }
        }
    }
}
