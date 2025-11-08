using System;

namespace banque
{
    public abstract class Account
    {
        public string Number { get; set; }
        public Person Owner { get; set; }
        private double Balance { get; set; } // encapsulation stricte

        public Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0;
        }

        // 🔹 Dépôt
        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("🫗 Montant invalide pour le dépôt.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"🍦 {amount:C} déposés sur le compte {Number}. Nouveau solde : {Balance:C}");
        }

        // 🔹 Retrait
        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("🫗 Montant invalide pour le retrait.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine($"🫗 Retrait refusé : solde insuffisant ({Balance:C}).");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"🍫 {amount:C} retirés du compte {Number}. Nouveau solde : {Balance:C}");
        }

        // 🔹 Accesseurs protégés
        public double GetBalance() => Balance;
        protected void SetBalance(double amount) => Balance = amount;

        // 🔹 MÉTHODE ABSTRAITE → redéfinie dans les classes filles
        protected abstract double CalculInterets();

        // 🔹 MÉTHODE PUBLIQUE → applique le taux d’intérêt calculé
        public void ApplyInterest()
        {
            double interets = CalculInterets();
            Balance += interets;
            Console.WriteLine($"🍓 Intérêts appliqués sur le compte {Number} : {interets:C}. Nouveau solde : {Balance:C}");
        }

        public override string ToString() =>
            $"Compte {Number} - Titulaire : {Owner} - Solde : {Balance:C}";
    }
}
