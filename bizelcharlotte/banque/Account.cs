using System;

namespace banque
{
    // Classe abstraite pour les comptes
    public abstract class Account
    {
        // Propriétés communes
        public string Number { get; set; }
        public double Balance { get; private set; }
        public Person Owner { get; set; }

        // Constructeur
        public Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0;
        }

        // Méthode virtuelle pour déposer de l'argent
        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(" Montant invalide pour le dépôt.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"{amount:C} déposés sur le compte {Number}. Nouveau solde : {Balance:C}");
        }

        // Méthode virtuelle pour retirer de l'argent
        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(" Montant invalide pour le retrait.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine($" Retrait refusé : solde insuffisant. Solde actuel : {Balance:C}");
                return;
            }

            Balance -= amount;
            Console.WriteLine($" {amount:C} retirés du compte {Number}. Nouveau solde : {Balance:C}");
        }

        // Méthode pour accéder au solde (lecture seule depuis l'extérieur)
        public double GetBalance()
        {
            return Balance;
        }

        public override string ToString()
        {
            return $"Compte {Number} - Titulaire : {Owner} - Solde : {Balance:C}";
        }

        // Méthode protégée pour permettre aux classes dérivées de modifier le solde
        protected void SetBalance(double amount)
        {
            Balance = amount;
        }
    }
}
