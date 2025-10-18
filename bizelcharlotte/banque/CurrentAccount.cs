using System;

namespace banque
{
    public class CurrentAccount
    {
        public string Number { get; set; }
        public double Balance { get; private set; }
        public double CreditLine { get; set; }
        public Person Owner { get; set; }

        public CurrentAccount(string number, Person owner, double creditLine = 0)
        {
            Number = number;
            Owner = owner;
            CreditLine = creditLine;
            Balance = 0;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(" Montant invalide pour le dépôt.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"{amount:C} déposés sur le compte {Number}. Nouveau solde : {Balance:C}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(" Montant invalide pour le retrait.");
                return;
            }

            if (Balance - amount < -CreditLine)
            {
                Console.WriteLine($" Retrait refusé : dépassement de la ligne de crédit ({CreditLine:C}).");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"{amount:C} retirés du compte {Number}. Nouveau solde : {Balance:C}");
        }

        public override string ToString()
        {
            return $"Compte {Number} - Titulaire : {Owner} - Solde : {Balance:C}";
        }
    }
}
