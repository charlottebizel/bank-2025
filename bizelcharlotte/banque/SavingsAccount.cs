using System;

namespace banque
{
    public class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }

        public SavingsAccount(string number, Person owner)
            : base(number, owner)
        {
            DateLastWithdraw = DateTime.MinValue;
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(" Montant invalide pour le retrait.");
                return;
            }

            if (amount > GetBalance())
            {
                Console.WriteLine($"Retrait refusé : solde insuffisant. Solde actuel : {GetBalance():C}");
                return;
            }

            SetBalance(GetBalance() - amount);
            DateLastWithdraw = DateTime.Now;
            Console.WriteLine($" {amount:C} retirés du compte épargne {Number}. Nouveau solde : {GetBalance():C}");
        }
    }
}
