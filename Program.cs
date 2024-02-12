using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, MenuItem> menu = new Dictionary<int, MenuItem>
        {
            {1, new MenuItem("Coca Cola 150 ml", 2.50)},
            {2, new MenuItem("Insalata di pollo", 5.20)},
            {3, new MenuItem("Pizza Margherita", 10.00)},
            {4, new MenuItem("Pizza 4 Formaggi", 12.50)},
            {5, new MenuItem("Pz patatine fritte", 3.50)},
            {6, new MenuItem("Insalata di riso", 8.00)},
            {7, new MenuItem("Frutta di stagione", 5.00)},
            {8, new MenuItem("Pizza fritta", 5.00)},
            {9, new MenuItem("Piadina vegetariana", 6.00)},
            {10, new MenuItem("Panino Hamburger", 7.90)}
        };

        List<MenuItem> selectedItems = new List<MenuItem>();

        while (true)
        {
            Console.WriteLine("==============MENU==============");
            DisplayMenu(menu);
            Console.WriteLine("11: Stampa conto finale e conferma");
            Console.WriteLine("==============MENU==============");

            Console.Write("Inserisci il numero del cibo desiderato: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice >= 1 && choice <= 10)
                {
                    selectedItems.Add(menu[choice]);
                    Console.WriteLine($"{menu[choice].Name} aggiunto al conto.");
                }
                else if (choice == 11)
                {
                    PrintFinalBill(selectedItems);
                    break;
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                }
            }
            else
            {
                Console.WriteLine("Input non valido. Riprova.");
            }
        }
    }

    static void DisplayMenu(Dictionary<int, MenuItem> menu)
    {
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key}: {item.Value.Name} (€ {item.Value.Price:F2})");
        }
    }

    static void PrintFinalBill(List<MenuItem> selectedItems)
    {
        Console.WriteLine("==============CONTO FINALE==============");
        foreach (var item in selectedItems)
        {
            Console.WriteLine($"{item.Name} (€ {item.Price:F2})");
        }

        double totalCost = selectedItems.Sum(item => item.Price) + 3.00;
        Console.WriteLine($"Costo totale: € {totalCost:F2}");
        Console.WriteLine("Servizio al tavolo incluso.(3 €)");
        Console.WriteLine("========================================");
    }
}

class MenuItem
{
    public string Name { get; }
    public double Price { get; }

    public MenuItem(string name, double price)
    {
        Name = name;
        Price = price;
    }
}
