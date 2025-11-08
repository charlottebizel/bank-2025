using System;
using banque.Exceptions;
using banque.Interfaces;

namespace banque.Models
{
    public abstract class Account : IBankAccount
    {
        public string Number { get; private set; }
        public Person Owner { get; private set; }
        private double balance;

        public double Balance => balance; // lecture seule

        protected Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            balance = 0;
        }

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");

            balance += amount;
            Console.WriteLine($"🍦 {amount:C} déposés sur le compte {Number}. Nouveau solde : {balance:C}");
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");
            if (amount > balance)
                throw new InsufficientBalanceException($"Solde insuffisant pour retirer {amount:C}.");

            balance -= amount;
            Console.WriteLine($"🍫 {amount:C} retirés du compte {Number}. Nouveau solde : {balance:C}");
        }

        protected void SetBalance(double amount) => balance = amount;

        protected abstract double CalculInterets();

        public void ApplyInterest()
        {
            double interets = CalculInterets();
            SetBalance(Balance + interets);
            Console.WriteLine($"🍓 Intérêts appliqués sur le compte {Number} : {interets:C}. Nouveau solde : {Balance:C}");
        }

        public override string ToString() => $"Compte {Number} - Titulaire : {Owner} - Solde : {Balance:C}";
    }
}
