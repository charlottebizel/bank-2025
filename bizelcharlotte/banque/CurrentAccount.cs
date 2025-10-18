using System;

namespace banque
{
    public class CurrentAccount : Account
    {
        public double CreditLine { get; set; }

        public CurrentAccount(string number, Person owner, double creditLine = 0)
            : base(number, owner)
        {
            CreditLine = creditLine;
        }

        // Redéfinition du retrait pour prendre en compte la ligne de crédit
        public override void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("❌ Montant invalide pour le retrait.");
                return;
            }

            if (GetBalance() - amount < -CreditLine)
            {
                Console.WriteLine($"🚫 Retrait refusé : dépassement de la ligne de crédit ({CreditLine:C})");
                return;
            }

            // On utilise la méthode protégée pour modifier le solde
            SetBalance(GetBalance() - amount);
            Console.WriteLine($"💸 {amount:C} retirés du compte courant {Number}. Nouveau solde : {GetBalance():C}");
        }
    }
}
