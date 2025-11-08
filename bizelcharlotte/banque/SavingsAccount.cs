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
                Console.WriteLine("🫗 Montant invalide pour le retrait.");
                return;
            }

            if (amount > GetBalance())
            {
                Console.WriteLine($"🫗 Retrait refusé : solde insuffisant ({GetBalance():C}).");
                return;
            }

            SetBalance(GetBalance() - amount);
            DateLastWithdraw = DateTime.Now;
            Console.WriteLine($"🥐 {amount:C} retirés du compte épargne {Number}. Nouveau solde : {GetBalance():C}");
        }

        // 🔹 Taux fixe 4.5 %
        protected override double CalculInterets()
        {
            return GetBalance() * 0.045;
        }

        public override string ToString()
        {
            string date = DateLastWithdraw == DateTime.MinValue ? "Aucun retrait" : DateLastWithdraw.ToString("dd/MM/yyyy HH:mm");
            return base.ToString() + $" - Dernier retrait : {date}";
        }
    }
}
