using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CarAppUpd;

namespace CarApp
{
    public class CarApp
    {
       
        static void Main()
        {
            MainMenu();
        }

        static void MainMenu()
        {
            //public static string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //public static string folder = Path.Combine(projectPath, "Data");
            //public static string FilePathCars = Path.Combine(folder, "Cars.txt");
            //public static string FilePathTrips = Path.Combine(folder, "Trips.txt");

            DataHandler CarPark = new DataHandler("Cars.txt");
            //CarPark.LoadTrips();
            CarPark.LoadCars();

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
                        EntryPoint.TilføjBil(CarPark);            
                        break;
                    case "2":
                        EntryPoint.PrintBilOplysninger(CarPark);
                        break;
                    case "3":
                        EntryPoint.TilføjKøretur(CarPark);
                        break;
                    case "4":
                        EntryPoint.PrintKøretur(CarPark);
                        break;
                    case "5":
                        EntryPoint.PrintBilregister(CarPark);
                        break;
                    case "6":
                        EntryPoint.OdometerPalindrome(CarPark);
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
