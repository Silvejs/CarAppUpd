using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppUpd
{
    class CarApp
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
                Console.WriteLine("1. Read Car Details");
                Console.WriteLine("2. Drive");
                Console.WriteLine("3. Calculate Trip Price");
                Console.WriteLine("4. IsPalindrome");
                Console.WriteLine("5. Print Car Details");
                Console.WriteLine("6. Print All Team Cars");
                Console.WriteLine("7. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ReadCarDetails();
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

        static void ReadCarDetails()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 1.Read Car Details");

            Console.WriteLine("Angiv venligst bilens oplysninger:");
            Console.WriteLine("Mærke:");
            string carBrand = Console.ReadLine();
            Console.WriteLine("Model:");
            string carModel = Console.ReadLine();
            Console.WriteLine("Årgang:");
            int carÅrgang = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kilometer tal:");
            int carKmTal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Du har angivet følgende oplysninger om din bil: Bil :{0} - Model: {1} - Årgang: {2} - Km tal: {3}", carBrand, carModel, carÅrgang, carKmTal);

            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }




        static void Drive()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 2.Drive");

            Console.WriteLine("\nStart engine!");               //hvordan laver man så man kan
                                                                //også hente en falsk værdi fra BOOL
            bool isEngineOn = true;

            Console.WriteLine("\nKilometertal: ");
            int carKmTal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nTrip: ");
            double distance = Convert.ToDouble(Console.ReadLine());


            if (isEngineOn == true)
            {
                carKmTal += Convert.ToInt32(distance);
                Console.WriteLine("\nTrip : {0} - Aktualiseret odometer: {1}", distance, carKmTal);
            }
            else
            {
                Console.WriteLine("\nStart engine for at læse odometer");
            }

            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }




        static void CalculateTripPrice()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 3.Calculate Trip Price");

            Console.WriteLine("Trip: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Angiv brændsstofpris per liter: ");
            double literPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Brændstofforbrug i km/l: ");
            double kmPerLiter = Convert.ToDouble(Console.ReadLine());

            double tripPrice = (distance / kmPerLiter) * literPrice;
            Console.WriteLine("Trip pris = {0}", tripPrice);

            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }
        static void IsPalindrome()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 4.IsPalindrome");

            Console.WriteLine("Odometer: ");
            int kmTal = Convert.ToInt32(Console.ReadLine());


            if (Palindrome(kmTal))
            {
                Console.WriteLine("{0} is a palindrome", kmTal);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome", kmTal);
            }

            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();


        }


        static bool Palindrome(int num)
        {
            int originalNumber = num;
            int remainder, reversedNumber = 0;

            while (num > 0)
            {
                remainder = num % 10;
                reversedNumber = (reversedNumber * 10) + remainder;
                num /= 10;
            }

            return originalNumber == reversedNumber;
        }




        static void PrintCarDetails()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 5.Print Car Details");
            string brand = "Ford";
            string model = "Focus";
            int årgang = 2010;
            int kmTal = 321123;
            double kmPerLiter = 23;


            Console.WriteLine("{0} {1} fra {2} med {3} - brændsstofforbrug på ca {4} km/l.", brand, model, årgang.ToString(), kmTal.ToString(), kmPerLiter.ToString());

            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }
        static void PrintAllTeamCars()
        {
            Console.Clear();
            Console.WriteLine("You selected Option 6.Print All Team Cars");




            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }

    }
}
