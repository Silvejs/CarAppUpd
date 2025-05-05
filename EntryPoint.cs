using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CarAppUpd;
using Microsoft.VisualBasic.FileIO;


namespace CarApp
{

    


    public class Menu
    {


        List<Car> bilRegister = new List<Car>();
        List<Trip> tripsRegister = new List<Trip>();
        public string FilePathCars = "Cars.txt";
        public string FilePathTrips = "Trips.txt";
        

        public void TilføjBil(DataHandler CarPark)                                             //bruger input - Biloplysninger - FIKSET!!!!
                                                                                    
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
            CarPark.bilRegister.Add(bil);
            CarPark.SaveCars(); 
            




            Console.WriteLine($"\n{bil.Brand} {bil.Model} {bil.Nummerplade} er blevet tilføjet bilregistret");
            Console.WriteLine();

            Console.WriteLine(bil.HeadCarDetails());
            //Console.WriteLine(bil.PrintCarDetails());
            for (int i = 0; i < CarPark.bilRegister.Count; i++)
            {
                var car = CarPark.bilRegister[i];
                Console.WriteLine($"[{i + 1}] {car.ToString()}");
            }



            Console.WriteLine("\nTilbage til hovedmenu...");

            Console.ReadKey();
        }



        public void PrintBilOplysninger(DataHandler CarPark)                                       /* bruger input  - Vælg en bil og print alle oplysninger  -  FIKSET!!!*/
        {
            

            Console.Clear();            
            Console.WriteLine("\nDu har valgt 2. Print bil oplysninger.");
            Console.WriteLine("\nIndtast nummerplade for at se biloplysninger");

            string nrPlade = Console.ReadLine();
            Car foundCar = CarPark.bilRegister.Find(bil => bil.Nummerplade == nrPlade);


            Console.Clear();
            Console.WriteLine($"=== Bil oplysninger med {nrPlade} ===".PadLeft(50));

            Console.WriteLine();

            if (foundCar == null)
            {
                Console.WriteLine("\nIngen biler er blevet oprettet endnu.");
            }
            else
            {

                Console.WriteLine(foundCar.HeadCarDetails());
                Console.WriteLine(foundCar.ToString());
            }


            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();
         
           
        }




        public void TilføjKøretur(DataHandler CarPark)                                  //FIKSET?       /*TODO - Tilføj ny køretur, med dato, starttidspunkt og sluttidspunkt og tilføjer den til en list*/
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
                CarPark.SaveTrips();
                
            }


            Console.WriteLine($"\nKøretur tilføjet til registreringsnummer: {nrplade}");

            Console.WriteLine();
            Console.WriteLine(køretur.HeadPrintTripDetails());
            Console.WriteLine($"{køretur.ToString()}");
         

            //Console.WriteLine(køretur.PrintTripDetails());

            Console.WriteLine();
            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();
        }






        public void PrintKøretur(DataHandler CarPark)                            //FIKSET??        /*TODO - Find en kåøretur tur som skal printes ud i consolen fx ud fra en dato*/
        /* Der skal kunne vælges en bestemt tur i tilfældet at der er flere ture med samme dato*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 4.Udskriv køretur oplysninger");

            while (true)
            {




                Console.WriteLine("1.Udskiv alle kørerturer for en registreret bil");
                Console.WriteLine("2.Udskirv køreturer for en registreret bil fra en udvalgt dato");
                Console.WriteLine("3.Tilbage til hovedmenu");
                string input = Console.ReadLine();



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
                            if (CarPark.tripsRegister.Count == 0)
                            {
                                Console.WriteLine("\nIngen køreturer er blevet oprettet endnu.");
                            }
                            else
                            {
                                Console.WriteLine(HeadPrintCarRegister());
                                for (int i = 0; i < CarPark.tripsRegister.Count; i++)
                                {
                                    var trip = CarPark.tripsRegister[i];
                                    Console.WriteLine($"[{i + 1}] {trip.ToString()}");
                                }
                            }

                        }
                            /*foreach (var car in foundCar)
                            {

                                var trips = car.PrintAllTrips();
                                foreach (var trip in trips)
                                { 
                                Console.WriteLine(trip.PrintTripDetails());
                                }

                            }*/

                            Console.WriteLine("Tilbage...");
                            break;







                    case "2":
                                Console.Clear();
                                Console.WriteLine("\nIndtast nummerplade for at se køreturene på dagen");
                                string nplade = Console.ReadLine();


                                List<Car> foundCarsWithTrips = bilRegister.Where(p => p.Nummerplade == nplade).ToList();
                                Console.WriteLine();



                                foreach (var car in foundCarsWithTrips)

                                {

                                    var trips = car.PrintAllTrips();
                                    Console.WriteLine("\nIndtast dato for at se alle køreturer på dagen (ÅÅÅÅ-MM-DD): ");
                                    DateOnly date = DateOnly.Parse(Console.ReadLine(), null);


                                    //string date = Console.ReadLine();

                                    //  List<Trip> tripsByDate = trips.Where(p => p.TripDate == date).ToList();




                                    Console.WriteLine(HeadPrintTripDetails());
                                    foreach (var trip in trips)
                                    {
                                        if (trip.TripDate.ToShortDateString() == date.ToShortDateString())
                                        {
                                            Console.WriteLine(trip.PrintTripDetails());
                                        }

                                        else if (trip.TripDate.ToShortDateString() != date.ToShortDateString())
                                        {
                                            Console.WriteLine("Ingen køreturer fundet den udvalgt dato!");
                                        }
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




        public void PrintBilregister(DataHandler CarPark)                                           /*TODO - FIKSET*/
        {
           // Udskriv liste med biler
            Console.Clear();
            Console.WriteLine("=== Bil oversigt ===".PadLeft(50));
            if (CarPark.bilRegister.Count == 0)
            {
                Console.WriteLine("\nIngen biler er blevet oprettet endnu.");
            }
            else
            {
                Console.WriteLine(HeadPrintCarRegister());
                for (int i = 0; i < CarPark.bilRegister.Count; i++)
                {
                    var car = CarPark.bilRegister[i];
                    Console.WriteLine($"[{i + 1}] {car.ToString()}");
                }
            }

            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();
        }


        public void OdometerPalindrome(DataHandler CarPark)                                /* Er odometeren en Palindrome?  - FIKSET */
        {

            Console.WriteLine("Indast nummerplade:");
            string nrplade = Console.ReadLine();
            Car foundCar = CarPark.bilRegister.Find(bil => bil.Nummerplade == nrplade);
            
            if (foundCar != null)
                {
                    Console.WriteLine($"Odometer = {foundCar.Odometer}");
                    Console.WriteLine($"Odometer er en palindrome = {foundCar.Palindrome()}");
                }
            else 
                {
                    Console.WriteLine("Registreringsnummer ikke fundet!!!");
                }

            Console.WriteLine("\nTilbage til hovedmenu...");
            Console.ReadKey();

        }

        public string HeadPrintCarRegister()
        {

            return "Brand".PadRight(15) + " | " + "Model".PadRight(15) + " | " + "Year".PadRight(15) + " | " + "Odometer".PadRight(15) + " | " + "Km/L".PadRight(15) + " | " + "Brændstoff".PadRight(15) + " | " + "Gear type".PadRight(15) + " | " + "Nummerplade".PadRight(15) + " | " +
                   "\n--------------- | --------------- | --------------- | --------------- | --------------- | --------------- | --------------- | ---------------";
        }

        public string HeadPrintTripDetails()
        {
            return
               $"Køreturdetaljere:" + 
               $"\nAfstand".PadRight(15) + " | " + "Dato".PadRight(15) + " | " + "Starttidspunkt".PadRight(15) + " | " + "Sluttidspunkt".PadRight(15) + " | " + "Trip Duration".PadRight(15) +
               $"\n--------------- | --------------- | --------------- | --------------- | ---------------";
        }

    }
}



