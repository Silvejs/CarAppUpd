using System;
using System.Collections.Generic;
using System.Linq;
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
        DateTime tripDate = DateTime.Now.Date;
        DateTime startTime = DateTime.Now;
        DateTime endTime = DateTime.Now;
        List<Car> bilRegister;
        string nummerplade;
        List<Trip> tripList;


        public void TilføjBil()                                             //bruger input - Biloplysninger - FIKSET
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




        public void TilføjKøretur()                                         /*TODO - Tilføj ny køretur, med dato, starttidspunkt og sluttidspunkt og tilføjer den til en list*/

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
            tripList.Add(trip);

            Console.WriteLine("\nKøretur tilføjet til bil: {0}", nummerplade);
            Console.WriteLine("\nPress any key to go back to the main menu...");
            Console.ReadKey();
        }


        public void PrintKøretur()                                      /*TODO*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 4.Print køretur oplysninger");







            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();


        }


        public void PrintBilregister()                                           /*TODO*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 5. Print bilregister");
            





            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }


        static void PrintAllTeamCars()                                          /*TODO*/
        {
            Console.Clear();
            Console.WriteLine("Du har valgt 1.Tilføj ny bil til registret: ");




            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }









        
           



            Console.WriteLine("Ønsket køretur i km : ");
            distance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Starttidspunkt for turen :");
            // user input omkring dato og start og sluttidspunkt for turen




            bil1.Drive();             // Drive metoden


            List<Trip> trips = new List<Trip>();
            Trip trip1 = new Trip(distance, tripDate, startTime, endTime.AddMinutes(37));
            Trip trip2 = new Trip(distance, tripDate, startTime.AddHours(1), endTime.AddHours(1).AddMinutes(23));



            //input fra bruger 
            Trip newTrip = new Trip(distance, tripDate, startTime, endTime.AddMinutes(37));
            bil1.Drive(newTrip);  

            Console.WriteLine("Angiv brændstofpris i kr: ");
            prisPerLiter = Convert.ToDouble(Console.ReadLine());

            newTrip.CalculateTripPrice(distance, prisPerLiter);        //Calculate Trip Price

            bil1.PrintCarDetails();      //Udskriv bilens oplysninger i konsollen




            //Trip trip1 = trips[0];        //initialisering af elementen i position 0 i listen
            Console.WriteLine();
            //trips[1].PrintTripDetails();    //Udskriv turens oplysninger i konsollen   
            newTrip.PrintTripDetails();     // Hvis man kender til den specifikke tur...ellers bruger man indeks


            Console.ReadKey();
        }
    }
}



// KIG TIL DATE ; START OG SLUTTIME...DER SKAL ARBEJDES LIDT MED DEM :
//udover det ...tjek hvordan kan man printe alle trips
