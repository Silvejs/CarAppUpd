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
                Console.WriteLine("Hovedmenu:");
                Console.WriteLine("1. Tilføj ny bil til registret");
                Console.WriteLine("2. Print bil oplysninger");
                Console.WriteLine("3. Tilføj ny køretur til en bil");                     
                Console.WriteLine("4. Print køretur oplysninger");
                Console.WriteLine("5. Print bilregister");
                Console.WriteLine("6. Is Odometer en Palindrome?");
                Console.WriteLine("7. Afslut");
                Console.Write("Vælg i menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TilføjBil();
                        break;
                    case "2":
                        PrintBilOplysninger();
                        break;
                    case "3":
                        TilføjKøretur();
                        break;
                    case "4":
                        PrintBilregister();
                        break;
                    case "5":
                        PrintBilregister();
                        break;
                    case "6":
                        OdometerPalindrome();
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
