using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace CarApp
{

    


    public class Menu
    {

        string brand;
        string model;
        int årgang;
        int odometer;
        double kmPerLiter;
        double distance;
        double prisPerLiter;
        GearType gearType;
        FuelType fuelType;
        DateTime tripDate;
        DateTime startTime;
        DateTime endTime;
        string nummerplade;
        List<Trip> tripList;
        List<Car> bilRegister = new List<Car>();
        string date;

        public void TilføjBil()                                             //bruger input - Biloplysninger 
                                                                                    // TJEK OM DET VIRKER ELLER FIND EN LØSNING!!!!
        {
          
            Console.Clear();
            Console.WriteLine("Du har valgt 1.Tilføj ny bil til registret.\nIndtast følgende biloplysninger: ");
                       
            Console.Clear();
            Console.WriteLine("Angiv mærke: ");
            brand = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Angiv model: ");
            model = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Angiv årgang: ");
            årgang = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv odometer: ");
            odometer = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv brændstofforbrug (km/L): ");
            kmPerLiter = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv brændstoftype: ");
            fuelType = Enum.Parse<FuelType>(Console.ReadLine().ToUpper());

            Console.Clear();
            Console.WriteLine("Angiv gear type: ");
            gearType = Enum.Parse<GearType>(Console.ReadLine().ToUpper());

            Console.Clear();
            Console.WriteLine("Angiv registreringsnummer: ");
            nummerplade = Console.ReadLine();

            Car bil = new Car(brand, model, årgang, odometer, kmPerLiter, fuelType, gearType, nummerplade);

            bil.PrintCarDetails();
            Console.WriteLine("\n{0} er blevet tilføjet bilregistret", bil.PrintCarDetails);
            bilRegister.Add(bil);

            Console.WriteLine("\nPress any key to go back to the main menu...");

            Console.ReadKey();
        }



        public void PrintBilOplysninger()                                       /* bruger input - FIKSET - Vælg en bil og print alle oplysninger */
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 2. Print bil oplysninger.");
            Console.WriteLine("Indtast nummerplade for at se biloplysninger");
            nummerplade = Console.ReadLine();
            foreach (var bil in bilRegister)
            {
                bilRegister.Find(bil => bil.Nummerplade.Contains(nummerplade));
                bil.PrintCarDetails();
            }
            
            Console.WriteLine("\nPress any key to go back to the main menu...");
            Console.ReadKey();
        }




        public void TilføjKøretur()                                  //FIKSET?       /*TODO - Tilføj ny køretur, med dato, starttidspunkt og sluttidspunkt og tilføjer den til en list*/
                                                                                    /* TJEK OM DET VIRKER ELLER FIND EN LØSNING*/

        {
            Console.Clear();
            Console.WriteLine("Du har valgt 3. Tilføj ny køretur.");

            Console.Clear();
            Console.WriteLine("Angiv registreringsnummer: ");
            nummerplade = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Angiv afstand i km: ");
            distance = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv køretur dato (ÅÅÅÅ-MM-DD): ");
            tripDate = Convert.ToDateTime(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv køretur starttidspunkt (TT:MM): ");
            startTime = Convert.ToDateTime(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Angiv køewtur sluttidspunkt (TT:MM): ");
            endTime = Convert.ToDateTime(Console.ReadLine());

            Trip trip = new Trip(distance, tripDate, startTime, endTime);


            foreach (var bil in bilRegister)                // der skal være tilknyttet nummerplade og ikke indeks - VIRKER DEN???? - SE OM DET VIRKER
            {
                if (bil.Nummerplade == nummerplade)
                {
                    
                    bil.Drive(trip);                     

                }

            }
            Console.WriteLine("\nKøretur tilføjet til bil: {0}", nummerplade);
            Console.WriteLine("\nPress any key to go back to the main menu...");
            Console.ReadKey();
        }






        public void PrintKøretur()                            //FIKSET??        /*TODO - Find en kåøretur tur som skal printes ud i consolen fx ud fra en dato*/
                                                                                /* Der skal kunne vælges en bestemt tur i tilfældet at der er flere ture med samme dato*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 4.Udskriv køretur oplysninger");

            while (true)
            {
                Car bil = new Car(brand, model, årgang, odometer, kmPerLiter, fuelType, gearType, nummerplade); 

                string input = Console.ReadLine();
                Console.WriteLine("1.Udskiv alle kørerturer for en registreret bil");
                Console.WriteLine("2.Udskirv køreturer for en registreret bil fra en udvalgt dato");
                Console.WriteLine("3.Tilbage til hovedmenu");

                switch (input)
                {
                    case ("1"):
                        bil.PrintAllTrips();
                        break;
                    case "2":
                        bil.GetTripsByDate();
                        break;
                     case ("3"):
                        Console.WriteLine("Afvent...");
                        return;
                     default:
                        break;

                }

            }

        }




        public void PrintBilregister()                                           /*TODO*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 5. Print bilregister");
            





            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }


        public bool OdometerPalindrome()                                /* Er odometeren en Palindrome?  -  FIKSET - TJEK OM DET VIRKER */
        {
            
            int originalNumber = odometer;
            int remainder, reversedNumber = 0;

            while (odometer > 0)
            {
                remainder = odometer % 10;
                reversedNumber = (reversedNumber * 10) + remainder;
                odometer /= 10;
            }

            return originalNumber == reversedNumber;
        }

       

            /*

            Console.WriteLine("Angiv brændstofpris i kr: ");
            prisPerLiter = Convert.ToDouble(Console.ReadLine());

            newTrip.CalculateTripPrice(distance, prisPerLiter);        //Calculate Trip Price

            bil1.PrintCarDetails();      //Udskriv bilens oplysninger i konsollen




            //Trip trip1 = trips[0];        //initialisering af elementen i position 0 i listen
            Console.WriteLine();
            //trips[1].PrintTripDetails();    //Udskriv turens oplysninger i konsollen   
            newTrip.PrintTripDetails();     // Hvis man kender til den specifikke tur...ellers bruger man indeks


            Console.ReadKey();



        */
        
    }
}



