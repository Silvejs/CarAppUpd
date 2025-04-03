using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarApp
{
    public class Test
    {
        static void Main()
        {
            string mærke;
            string model;
            int årgang;
            int odometer;
            double kmPerLiter;
            double distance;
            double literPrice;
            GearType geartype;
            FuelType fuelType;
            DateTime tripDate = DateTime.Now.Date;
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;

            //bruger input (ekstern)
            Console.WriteLine("Angiv mærke: ");
            mærke = Console.ReadLine();
            Console.WriteLine("Angiv model: ");
            model = Console.ReadLine();
            Console.WriteLine("Angiv årgang: ");
            årgang = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Angiv odometer: ");
            odometer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Angiv kmPerLiter: ");
            kmPerLiter = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Angiv brændstoftype: ");
            fuelType = Enum.Parse<FuelType>(Console.ReadLine().Substring(0).ToUpper());
            
            //Hvordan gør man at indtaste med LOWER eller UPPER case ??

            //skal man laver en switch? hvor man tager den individuelle svar og kører den til at være to UPPER eller LOWER ?
            
            // string fuel = Console.ReadLine().ToLower();   
            //if (fuel == "benzin")
            //{
            //  fuelType = FuelType.Benzin;
            //}
            //else if (fuel == "diesel")
            //{
            //    fuelType = FuelType.Diesel;
            //}
            //else if (fuel == "hybrid")
            //{
            //    fuelType = FuelType.Hybrid;
            //}
            //else if (fuel == "elektrisk")
            //{
            //    fuelType = FuelType.Elektrisk;
            //}




            Console.WriteLine("Angiv gear type: ");
            geartype = Enum.Parse<GearType>(Console.ReadLine());


            Car bil1 = new Car(mærke, model, årgang, odometer, kmPerLiter, fuelType, geartype);         //instansiering af biler med constructor
            // Car Bil2 = new Car(mærke, model, årgang, odometer, kmPerLiter);



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
            literPrice = Convert.ToDouble(Console.ReadLine());

            newTrip.CalculateTripPrice(distance, literPrice);        //metoden er fra Trip Klassen

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
