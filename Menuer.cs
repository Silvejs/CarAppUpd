using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp
{
    internal class CarApp
    {
        static void Main()
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Tilføj ny bil til registret");
                Console.WriteLine("2. Print bil oplysninger");
                Console.WriteLine("3. Tilføj ny køretur");                     
                Console.WriteLine("4. Print køretur oplysninger");
                Console.WriteLine("5. ");
                Console.WriteLine("6. Print bilregister");
                Console.WriteLine("7. Afslut");
                Console.Write("Vælg i menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TilføjNyBil()();
                        break;
                    case "2":
                        Drive();
                        break;
                    case "3":
                        CalculateTripPrice();
                        break;
                    case "4":
                        IsPalindrome();
                        break;
                    case "5":
                        PrintCarDetails();
                        break;
                    case "6":
                        PrintAllTeamCars();
                        break;
                    case "7":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        } 
    }
}
