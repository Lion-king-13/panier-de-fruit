// Créez un jeu de gestion de panier de fruits au marché à l'aide d'un tableau de chaine de caractères.
// L'utilisateur peut ajouter maximum 5 fruits, les retirer, les afficher et les rechercher.
// Gérez les doublons lors de l'ajout.
// Permettez à l'utilisateur de quitter le jeu via le menu.

string[] panier = new string[5];
int count = 0;
string choice = "";
bool running = true;

while (running)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Ajouter un fruit");
    Console.WriteLine("2. Retirer un fruit");
    Console.WriteLine("3. Afficher les fruits");
    Console.WriteLine("4. Rechercher un fruit");
    Console.WriteLine("5. Quitter");
    Console.Write("Choisissez une option (1-5): ");

    choice = Console.ReadLine();


    switch (choice)
    {
        case "1":
            if (count >= panier.Length)
            {
                Console.WriteLine("Le panier est plein. Vous ne pouvez pas ajouter plus de fruits.");
            }
            else
            {
                Console.Write("Entrez le nom du fruit à ajouter: ");
                string addFruit = Console.ReadLine();
                if (Array.Exists(panier, fruit => fruit != null && fruit.Equals(addFruit, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Ce fruit est déjà dans le panier.");
                }
                else
                {
                    panier[count] = addFruit;
                    count++;
                    Console.WriteLine($"{addFruit} a été ajouté au panier.");
                }
            }
            break;
        case "2":
            Console.Write("Entrez le nom du fruit à retirer: ");
            string removeFruit = Console.ReadLine();
            int index = Array.FindIndex(panier, fruit => fruit != null && fruit.Equals(removeFruit, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                panier[index] = null;
                count--;
                Console.WriteLine($"{removeFruit} a été retiré du panier.");
            }
            else
            {
                Console.WriteLine("Ce fruit n'est pas dans le panier.");
            }
            break;
        case "3":
            Console.WriteLine("Fruits dans le panier:");
            foreach (var fruit in panier)
            {
                if (fruit != null)
                {
                    Console.WriteLine(fruit);
                }
            }
            break;
        case "4":
            Console.Write("Entrez le nom du fruit à rechercher: ");
            string searchFruit = Console.ReadLine();
            if (Array.Exists(panier, fruit => fruit != null && fruit.Equals(searchFruit, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"{searchFruit} est dans le panier.");
            }
            else
            {
                Console.WriteLine($"{searchFruit} n'est pas dans le panier.");
            }
            break;
        case "5":
            running = false;
            Console.WriteLine("Ce fut un plaisir, bye !");
            break;
        default:
            Console.WriteLine("Option invalide. Veuillez choisir une option entre 1 et 5.");
            break;
    }
}