using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CarApp
{



    public class Car
    {
        private string _brand;
        private string _model;
        private int _årgang;                       //CAR CLASS PROPERTIES
        private int _odometer;
        private double _distance;
        private bool _isEngineOn;
        private FuelType _fuelType;
        private List<Trip> _trips;
        private GearType _gearType;
        private double _kmPerLiter; 
        private double _fuelUsed;
        private double _literPrice;
        private List<Car> bilRegister;
        private string _nummerplade;
        private string _date;








        public string Brand                                      // getter setter for BRAND property
        {
            get { return _brand; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _brand = value;
                }
                else
                {
                    Console.WriteLine("Invalid typing!");
                }
            }

        }

        public string Model         // getter setter for MODEL property
        {
            get { return _model; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))      // ! = NOT ...meaning that if is null or white space 
                                                            // needs to be false for the VARIABEL to get a value
                {
                    _model = value;
                }
                else
                {
                    Console.WriteLine("Invalid typing!");
                }
            }
        }

        public int Årgang             // getter setter for YEAR property
        {
            get { return _årgang; }
            set
            {
                if (value > 0)
                {
                    _årgang = value;
                }
                else
                {
                    Console.WriteLine("Invalid typing!");
                }
            }
        }

        public int Odometer                                 // getter setter for MILEAGE property
        {
            get { return _odometer; }
            set
            {
                if (value > 0)
                {
                    _odometer = value;
                }
                else
                {
                    Console.WriteLine("Invalid typing!");
                }
            }
        }

        public double Distance                              // getter setter for DISTANCE property
        {
            get { return _distance; }
            set
            {
                if (value > 0)
                {
                    _distance = value;
                }
                else
                {
                    Console.WriteLine("Invalid typing!");
                }
            }
        }

        public bool IsEngineOn                              //bool IsEngineOn property
        {
            get { return _isEngineOn; }
            set
            {
                if (!_isEngineOn == true)
                {
                    _isEngineOn = value;
                }
                else
                {
                    Console.WriteLine("Start Engine");
                }
            }
        }

        public double KmPerLiter { get {return _kmPerLiter;} set {_kmPerLiter = value; } }

        public double FuelUsed { get { return _fuelUsed; } set { _fuelUsed = value; } }

        public double LiterPrice { get { return _literPrice; } set { _literPrice = value; } }

        public FuelType FuelType { get { return _fuelType; } set { _fuelType = value; } }

        public GearType GearType { get { return _gearType; } set { _gearType = value; } }

        public string Nummerplade { get { return _nummerplade; } set {_nummerplade = value; } }

        public string Date { get { return _date; } set { _date = value; } }  





        public Car(string brand, string model, int årgang, int odometer, double kmPerLiter, FuelType fuelType, GearType gearType, string nummerplade)        /* CAR CONSTRUCTOR*/
        {
            Brand = brand;
            Model = model;
            Årgang = årgang ;
            Odometer = odometer;
            KmPerLiter = kmPerLiter;
            _trips = new List<Trip>();
            _fuelType = fuelType;
            _gearType = gearType;
            _nummerplade = nummerplade;

        }




        public void Drive()
        {
            if (!IsEngineOn)
            {
                Console.WriteLine("Tænd bilen");
            }
            else
            {
                Odometer += Convert.ToInt32(Distance);
                Console.WriteLine("Opdateret odometer: {0}", Odometer);
            }

        }              //Opdaterer odometer med den nye angivet trip 

                                        
        public string PrintCarDetails()                                     //Print Car Details i consollen -> nu med opdateret kilometer tal
        {

            return $"Nummerplade".PadRight(15) + "|" +  "Brand".PadRight(15) + "|" + "Model".PadRight(15) + "|" + "Year".PadRight(15) + "|" + "Mileage".PadRight(15) + "|" + "Km/L".PadRight(15) + "Brændstof".PadRight(15) + "Gear".PadLeft(15) +
                   $"\n---------------|---------------|---------------|---------------|---------------|---------------|---------------|---------------" +
                   $"\n{Nummerplade.PadRight(15)} + {Brand.PadRight(15)}  |  {Model.PadRight(15)} | {Årgang.ToString().PadRight(15)} | {Odometer.ToString().PadRight(15)} | {KmPerLiter.ToString().PadRight(15)} | {FuelType.ToString().PadRight(15)} | {GearType.ToString().PadLeft(15)}";
       
        }


        public void Drive(Trip newTrip)
        {
            if (!IsEngineOn)
            { 
                Odometer += (int)newTrip.Distance;
                _trips.Add(newTrip);
            }
           

            //Drive-metoden vil være ansvarlig for
            //      at kontrollere om motoren er tændt,
            //      beregne brændstofforbrug og turpris, og
            //      opdatere bilens kilometerstand (Odometer).
            //Denne metode kan ligge i Car-klassen, mens den tager oplysninger fra Trip-objektet som parameter.
        }

        public List<Trip> PrintAllTrips()
        {
            return new List<Trip>(_trips);



            //foreach (var trip in _trips)                          //DET KAN MAN GODT MEN HUSK SIMPLITET - KAN BRUGES cw I MAIN
            //{
            //    Console.WriteLine(trip.PrintTripDetails());       //Skriv parametre som skal udskrives i consolen ift TRIP
            //}
        

        //GetTripsByDate-metoden skal gennemgå alle Trip-objekter og finde de ture, der blev gennemført på en specifik dato.
        //Denne metode skal ligge i Car-klassen og benytte et loop til at søge gennem alle ture.
        }


        public List<Trip> GetTripsByDate()                       //vi arbejder med TRIP klassen derfor er datatypen i metoden LIST
        {
            List<Trip> tripsByDate = new List<Trip>();              //instansieriser en nye liste for at gemme de ture med den angivne dato

            Date = Convert.ToDateTime(Date).ToShortDateString();    //instansieriser = husk at convertere til dato


            foreach (Trip trip in _trips)                           //foreach loop for at tjekke hver trip om den indeholder datoen
            {
                if (trip.TripDate.ToShortDateString() == Date)
                {
                    tripsByDate.Add(trip);                          //gem turen til en anden liste
                }

            }

            return tripsByDate;                                     //returner en liste med datoerne når metoden er kaldt ud i MAIN

        }


        public bool Palindrome()                                /* Er odometeren en Palindrome? */
        {
            _odometer = Odometer;
            int originalNumber = Odometer;
            int remainder, reversedNumber = 0;

            while (Odometer > 0)
            {
                remainder = Odometer % 10;
                reversedNumber = (reversedNumber * 10) + remainder;
                Odometer /= 10;
            }

            return originalNumber == reversedNumber;
        }

    }


    public enum FuelType                                                    /* enum for Fuel Type */
    {
             BENZIN,                                                        /* find en løsning til at sætte alle bogstaver TO LOWER og den førstebogstav til TO UPPER...*/
             DIESEL,                                                        /*  -kræver at man tage indekset for første bogstaver som skal gøres TOUPPER ved udskrivning??  */
             HYBRID,
             ELEKTRISK
    }

    public enum GearType                                                    /* enum for Gear Type */
    {                                                                       /* - Prøv ligesom i Fuel Type at finde en løsning så den udskriver objekterne med kun den første bogstave To.Upper*/
        AUTOMATISK,
        MANUAL
    }




}


