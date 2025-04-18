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
            Menu EntryPoint = new Menu();
            var bil = new CarApp();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hovedmenu:");
                Console.WriteLine("1. Tilføj ny bil til registret");
                Console.WriteLine("2. Print bil oplysninger via nummerplade");
                Console.WriteLine("3. Tilføj ny køretur");                     
                Console.WriteLine("4. Print køretur oplysninger");
                Console.WriteLine("5. Print bilregister");
                Console.WriteLine("6. Is Odometer en Palindrome?");
                Console.WriteLine("7. Afslut");
                Console.Write("Vælg i menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EntryPoint.TilføjBil();            
                        break;
                    case "2":
                        EntryPoint.PrintBilOplysninger();
                        break;
                    case "3":
                        EntryPoint.TilføjKøretur();
                        break;
                    case "4":
                        EntryPoint.PrintKøretur();
                        break;
                    case "5":
                        EntryPoint.PrintBilregister();
                        break;
                    case "6":
                        EntryPoint.OdometerPalindrome();
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
