using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;


namespace CarApp
{

    


    public class Menu
    {


           
        List<Car> bilRegister = new List<Car>();
       

        public void TilføjBil()                                             //bruger input - Biloplysninger - FIKSET!!!!
                                                                                    
        {
            
            Console.Clear();
            Console.WriteLine("\nDu har valgt 1.Tilføj ny bil til registret.\nIndtast følgende biloplysninger: ");
                       
            Console.Clear();
            Console.WriteLine("\nAngiv mærke: ");
            string brand = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\nAngiv model: ");
            string model = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\nAngiv årgang: ");
            int årgang = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\nAngiv odometer: ");
            int odometer = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\nAngiv brændstofforbrug (km/L): ");
            double kmPerLiter = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\nAngiv brændstoftype: ");
            FuelType fuelType = Enum.Parse<FuelType>(Console.ReadLine().ToUpper());

            Console.Clear();
            Console.WriteLine("\nAngiv gear type: ");
            GearType gearType = Enum.Parse<GearType>(Console.ReadLine().ToUpper());

            Console.Clear();
            Console.WriteLine("\nAngiv registreringsnummer: ");
            string nummerplade = Console.ReadLine();

            Car bil = new Car(brand, model, årgang, odometer, kmPerLiter, fuelType, gearType, nummerplade);
            bilRegister.Add(bil);   
            
            
          
            
            Console.WriteLine($"\n{bil.Brand} {bil.Model} er blevet tilføjet bilregistret");
            Console.WriteLine();

            //Console.WriteLine($"Brand".PadRight(15) + " | " + "Model".PadRight(15) + " | " + "Year".PadRight(15) + " | " + "Odometer".PadRight(15) + " | " + "Nummerplade".PadRight(15) + " | " +
            //                $"\n--------------- | --------------- | --------------- | --------------- | ---------------");

            Console.WriteLine(HeadPrintCarDetails());
            Console.WriteLine(bil.PrintCarDetails());



            Console.WriteLine("\nTilbage til hovedmenu...");

            Console.ReadKey();
        }



        public void PrintBilOplysninger()                                       /* bruger input  - Vælg en bil og print alle oplysninger  -  FIKSET!!!*/
        {
            Console.Clear();            
            Console.WriteLine("\nDu har valgt 2. Print bil oplysninger.");
            Console.WriteLine("\nIndtast nummerplade for at se biloplysninger");

            string nrplade = Console.ReadLine();
            List<Car> foundCar = bilRegister.Where(p => p.Nummerplade == nrplade).ToList();
            Console.WriteLine();


            //Console.WriteLine($"Brand".PadRight(15) + " | " + "Model".PadRight(15) + " | " + "Year".PadRight(15) + " | " + "Odometer".PadRight(15) + " | " + "Nummerplade".PadRight(15) + " | " +
            //                $"\n--------------- | --------------- | --------------- | --------------- | ---------------");

            Console.WriteLine(HeadPrintCarDetails());

            foreach (var bil in foundCar)                                                 
            {
                if (foundCar != null)
                {
                    Console.WriteLine(bil.PrintCarDetails());
                }
                else
                {
                    Console.WriteLine("\nRegistreringsnummer ikke fundet!");
                }
            }
            
            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();
        }




        public void TilføjKøretur()                                  //FIKSET?       /*TODO - Tilføj ny køretur, med dato, starttidspunkt og sluttidspunkt og tilføjer den til en list*/
                                                                                    /* TJEK OM DET VIRKER ELLER FIND EN LØSNING*/

        {
            Console.Clear();
            Console.WriteLine("Du har valgt 3. Tilføj ny køretur.");

            Console.Clear();
            Console.WriteLine("Angiv registreringsnummer: ");
            string nrplade = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Angiv afstand i km: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv køretur dato (ÅÅÅÅ-MM-DD): ");
            DateTime tripDate = Convert.ToDateTime(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv køretur starttidspunkt (TT:MM): ");
            DateTime startTime = Convert.ToDateTime(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv køretur sluttidspunkt (TT:MM): ");
            DateTime endTime = Convert.ToDateTime(Console.ReadLine());

            Trip køretur = new Trip(distance, tripDate, startTime, endTime);


            List<Car> foundCar = bilRegister.Where(p => p.Nummerplade == nrplade).ToList();

            foreach (var bil in foundCar)                                           // der skal være tilknyttet nummerplade og ikke indeks - VIRKER DEN???? - SE OM DET VIRKER
            {

                    bil.Drive(køretur);
                
            }


            Console.WriteLine($"\nKøretur tilføjet til registreringsnummer: {nrplade}");

            Console.WriteLine();
            Console.WriteLine(HeadPrintTripDetails());
            Console.WriteLine(køretur.PrintTripDetails());

            Console.WriteLine();
            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();
        }






        public void PrintKøretur()                            //FIKSET??        /*TODO - Find en kåøretur tur som skal printes ud i consolen fx ud fra en dato*/
                                                                                /* Der skal kunne vælges en bestemt tur i tilfældet at der er flere ture med samme dato*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 4.Udskriv køretur oplysninger");

            while (true)
            {   
                
                

                string input = Console.ReadLine();
                Console.WriteLine("1.Udskiv alle kørerturer for en registreret bil");
                Console.WriteLine("2.Udskirv køreturer for en registreret bil fra en udvalgt dato");
                Console.WriteLine("3.Tilbage til hovedmenu");

               switch (input)
                {
                    case ("1"):

                        Console.Clear();
                        Console.WriteLine("\nIndtast nummerplade for at se køreturene for en bil: ");
                        string nrplade = Console.ReadLine();
                        

                        List<Car> foundCar = bilRegister.Where(p => p.Nummerplade == nrplade).ToList();
                        Console.WriteLine();


                        foreach (var car in foundCar)
                        {
                           
                            var trips = car.PrintAllTrips();
                            foreach (var trip in trips)
                            { 
                            Console.WriteLine(trip.PrintTripDetails());
                            }

                        }

                        Console.WriteLine("Tilbage...");
                        break;







                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nIndtast nummerplade for at se køreturene på dagen");
                        string nplade = Console.ReadLine();
                        
                        
                        List<Car> foundCarsTrips = bilRegister.Where(p => p.Nummerplade == nplade).ToList();
                        Console.WriteLine();

                        Console.WriteLine("\nIndtast dato for at se alle køreturer på dagen (ÅÅÅÅ-MM-DD): ");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());


                        foreach (var car in foundCarsTrips)

                        {

                            var trips = car.GetTripsByDate();
                            List<Trip> tripsByDate = trips.Where(p => p.TripDate == date).ToList();


                            foreach (var trip in tripsByDate)
                            {
                                Console.WriteLine(trip.PrintTripDetails());
                            }

                            
                        }

                        Console.WriteLine("\nTilbage...");
                        break;




                     case ("3"):
                        Console.WriteLine("Afvent...");
                        return;

                     default:
                        break;

                }

            }

        }




        public void PrintBilregister()                                           /*TODO - FIKSET*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 5. Print bilregister");
            //Console.WriteLine($"Brand".PadRight(15) + " | " + "Model".PadRight(15) + " | " + "Year".PadRight(15) + " | " + "Odometer".PadRight(15) + " | " + "Nummerplade".PadRight(15) + " | " +
            //                  $"\n--------------- | --------------- | --------------- | --------------- | ---------------");

            Console.WriteLine(HeadPrintCarDetails());


            foreach (var bil in bilRegister) 
            {
                Console.WriteLine();
                Console.WriteLine(bil.PrintCarDetails()); 
            }




            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();
        }


        public void OdometerPalindrome()                                /* Er odometeren en Palindrome?  - FIKSET */
        {

            Console.WriteLine("Indast nummerplade:");
            string nrplade = Console.ReadLine();
            Car foundCar = bilRegister.FirstOrDefault(bil => bil.Nummerplade == nrplade);

            
            if (foundCar != null)
                {
                    Console.WriteLine($"Odometer = {foundCar.Odometer}");
                    Console.WriteLine($"Odometer er en palindrome = {foundCar.Palindrome(foundCar.Odometer)}");
                }
            else 
                {
                    Console.WriteLine("Registreringsnummer ikke fundet!!!");
                }

            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();

        }

        public string HeadPrintCarDetails()
        {

            return "Brand".PadRight(15) + " | " + "Model".PadRight(15) + " | " + "Year".PadRight(15) + " | " + "Odometer".PadRight(15) + " | " + "Nummerplade".PadRight(15) + " | " +
                   "\n--------------- | --------------- | --------------- | --------------- | ---------------";
        }

        public string HeadPrintTripDetails()
        {
            return
               "Køreturdetaljere:" + "\nAfstand".PadRight(15) + " | " + "Dato".PadRight(15) + " | " + "Starttidspunkt".PadRight(15) + " | " + "Sluttidspunkt".PadRight(15) + " | " + "Trip Duration".PadRight(15) +
               "\n--------------- | --------------- | --------------- | --------------- | ---------------";
        }

    }
}



