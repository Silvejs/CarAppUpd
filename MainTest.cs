using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarApp
{
    public class Menuer
    {
        public void TilføjNyBil()
        {
            string mærke;
            string model;
            int årgang;
            int odometer;
            double kmPerLiter;
            double distance;
            double prisPerLiter;
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
            fuelType = Enum.Parse<FuelType>(Console.ReadLine());
            Console.WriteLine("Angiv gear type: ");
            geartype = Enum.Parse<GearType>(Console.ReadLine().ToUpper());
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









        Car bil1 = new Car(mærke, model, årgang, odometer, kmPerLiter, fuelType, geartype);         //instansiering af biler med constructor
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
