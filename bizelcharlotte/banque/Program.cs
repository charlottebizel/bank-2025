using System;
using System.Globalization;

namespace banque
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // affichage des € correctement

            Bank banque = new Bank("Banque Centrale");

            bool quitter = false;

            while (!quitter)
            {
                Console.WriteLine("\n=== MENU BANQUE ===");
                Console.WriteLine("1. Créer une personne et un compte");
                Console.WriteLine("2. Dépôt sur un compte");
                Console.WriteLine("3. Retrait sur un compte");
                Console.WriteLine("4. Afficher le solde d’un compte");
                Console.WriteLine("5. Supprimer un compte");
                Console.WriteLine("6. Somme totale des comptes d’une personne");
                Console.WriteLine("0. Quitter");
                Console.Write("Choix : ");

                string choix = Console.ReadLine();
                Console.WriteLine();

                switch (choix)
                {
                    case "1":
                        CreerCompte(banque);
                        break;

                    case "2":
                        Depot(banque);
                        break;

                    case "3":
                        Retrait(banque);
                        break;

                    case "4":
                        AfficherSolde(banque);
                        break;

                    case "5":
                        SupprimerCompte(banque);
                        break;

                    case "6":
                        TotalPersonne(banque);
                        break;

                    case "0":
                        quitter = true;
                        Console.WriteLine("Merci d’avoir utilisé la Banque Centrale !");
                        break;

                    default:
                        Console.WriteLine(" Choix invalide, réessaie !");
                        break;
                }
            }
        }

        static void CreerCompte(Bank banque)
        {
            Console.Write("Prénom du titulaire : ");
            string prenom = Console.ReadLine();

            Console.Write("Nom du titulaire : ");
            string nom = Console.ReadLine();

            Console.Write("Date de naissance (JJ/MM/AAAA) : ");
            DateTime naissance = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Person client = new Person(prenom, nom, naissance);

            Console.Write("Numéro de compte : ");
            string numero = Console.ReadLine();

            Console.Write("Ligne de crédit autorisée (€) : ");
            double credit = double.Parse(Console.ReadLine());

            CurrentAccount compte = new CurrentAccount(numero, client, credit);
            banque.AddAccount(compte);
        }

        static void Depot(Bank banque)
        {
            Console.Write("Numéro de compte : ");
            string num = Console.ReadLine();

            Console.Write("Montant à déposer (€) : ");
            double montant = double.Parse(Console.ReadLine());

            if (banque.Accounts.TryGetValue(num, out Account compte))
                compte.Deposit(montant);
            else
                Console.WriteLine("Compte introuvable !");
        }

        static void Retrait(Bank banque)
        {
            Console.Write("Numéro de compte : ");
            string num = Console.ReadLine();

            Console.Write("Montant à retirer (€) : ");
            double montant = double.Parse(Console.ReadLine());

            if (banque.Accounts.TryGetValue(num, out Account compte))
                ((CurrentAccount)compte).Withdraw(montant);
            else
                Console.WriteLine("Compte introuvable !");
        }

        static void AfficherSolde(Bank banque)
        {
            Console.Write("Numéro de compte : ");
            string num = Console.ReadLine();

            double solde = banque.GetBalance(num);
            Console.WriteLine($"Solde actuel du compte {num} : {solde:C}");
        }

        static void SupprimerCompte(Bank banque)
        {
            Console.Write("Numéro de compte à supprimer : ");
            string num = Console.ReadLine();
            banque.DeleteAccount(num);
        }

        static void TotalPersonne(Bank banque)
        {
            Console.Write("Prénom de la personne : ");
            string prenom = Console.ReadLine();

            Console.Write("Nom de la personne : ");
            string nom = Console.ReadLine();

            double total = 0;
            bool trouve = false;

            foreach (var acc in banque.Accounts.Values)
            {
                if (acc.Owner.FirstName.Equals(prenom, StringComparison.OrdinalIgnoreCase) &&
                    acc.Owner.LastName.Equals(nom, StringComparison.OrdinalIgnoreCase))
                {
                    total += acc.Balance;
                    trouve = true;
                }
            }

            if (trouve)
                Console.WriteLine($"Somme totale des comptes de {prenom} {nom} : {total:C}");
            else
                Console.WriteLine("Aucun compte trouvé pour cette personne.");
        }
    }
}
