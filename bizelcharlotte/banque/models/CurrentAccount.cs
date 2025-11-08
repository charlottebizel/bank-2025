using System;
using banque.Exceptions;


namespace banque.Models
{
    public class CurrentAccount : Account
    {
        private double creditLine;

        public double CreditLine
        {
            get => creditLine;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit doit être positive.");
                creditLine = value;
            }
        }

        public CurrentAccount(string number, Person owner, double creditLine = 0) 
            : base(number, owner)
        {
            CreditLine = creditLine;
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");

            if (Balance - amount < -CreditLine)
                throw new InsufficientBalanceException($"Retrait impossible : dépassement de la ligne de crédit ({CreditLine:C}).");

            SetBalance(Balance - amount);
            Console.WriteLine($"🍫 {amount:C} retirés du compte courant {Number}. Nouveau solde : {Balance:C}");
        }

        protected override double CalculInterets()
        {
            double taux = Balance >= 0 ? 0.03 : 0.0975;
            return Balance * taux;
        }
    }
}
