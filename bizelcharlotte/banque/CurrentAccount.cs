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

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(" 🫗 Montant invalide pour le retrait.");
                return;
            }

            if (GetBalance() - amount < -CreditLine)
            {
                Console.WriteLine($"🫗 Retrait refusé : dépassement de la ligne de crédit ({CreditLine:C}).");
                return;
            }

            SetBalance(GetBalance() - amount);
            Console.WriteLine($"🍫 {amount:C} retirés du compte courant {Number}. Nouveau solde : {GetBalance():C}");
        }

        // 🔹 Taux d’intérêt selon le solde
        protected override double CalculInterets()
        {
            double taux = GetBalance() >= 0 ? 0.03 : 0.0975;
            return GetBalance() * taux;
        }
    }
}
