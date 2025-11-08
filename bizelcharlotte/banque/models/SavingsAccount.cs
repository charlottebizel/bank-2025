using System;
using banque.Exceptions;


namespace banque.Models
{
    public class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }

        public SavingsAccount(string number, Person owner) : base(number, owner)
        {
            DateLastWithdraw = DateTime.MinValue;
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");

            if (amount > Balance)
                throw new InsufficientBalanceException($"Solde insuffisant pour retirer {amount:C}.");

            SetBalance(Balance - amount);
            DateLastWithdraw = DateTime.Now;
            Console.WriteLine($"🥐 {amount:C} retirés du compte épargne {Number}. Nouveau solde : {Balance:C}");
        }

        protected override double CalculInterets() => Balance * 0.045;

        public override string ToString()
        {
            string date = DateLastWithdraw == DateTime.MinValue ? "Aucun retrait" : DateLastWithdraw.ToString("dd/MM/yyyy HH:mm");
            return base.ToString() + $" - Dernier retrait : {date}";
        }
    }
}
