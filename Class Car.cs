using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int _year;                       //CAR CLASS PROPERTIES
        private int _odometer;
        private double _distance;
        private double _fuelConsumption;
        private bool _isEngineOn;
        private FuelType _fuelType;
        private List<Trip> _trips;
        private GearType _gearType;
        private double _kmPerLiter;
        private double _fuelUsed;
        private double _literPrice;




        public string Brand                 // getter setter for BRAND property
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
        public int Year             // getter setter for YEAR property
        {
            get { return _year; }
            set
            {
                if (value > 0)
                {
                    _year = value;
                }
                else
                {
                    Console.WriteLine("Invalid typing!");
                }
            }
        }
        public int Odometer          // getter setter for MILEAGE property
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
        public double FuelConsumption           //getter setter for FUEL COMSPUMPTION  property
        {
            get { return _fuelConsumption; }
            set
            {
                if (value > 0)
                {
                    _fuelConsumption = value;
                }
                else
                {
                    Console.WriteLine("Invalid typing!");
                }
            }
        }
        public double Distance             // getter setter for DISTANCE property
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
        public bool IsEngineOn          //bool isengineon property
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
        public double KmPerLiter  { get { return _kmPerLiter; } set { _kmPerLiter = value;  } }
        public double FuelUsed { get { return _fuelUsed; } set { _fuelUsed = value; } }
        public double LiterPrice { get { return _literPrice; } set { _literPrice = value; } }




        //CONSTRUCTOR
        public Car(string brand, string model, int year, int mileage, double fuelConsumption, FuelType fuelType, GearType gearType)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Odometer = mileage;
            FuelConsumption = fuelConsumption;
            _trips = new List<Trip>();
            _fuelType = fuelType;
            _gearType = gearType;

        }


        //Opdaterer odometer med den nye angivet trip 
        //public void Drive()
        //{
         //   if (!IsEngineOn)
          //  {
           //     Console.WriteLine("Tænd bilen");
           // }
           // else
          //  {
         //       Odometer += Convert.ToInt32(Distance);
        //    }

      //  }



        //Print Car Details i consollen -> nu med opdateret kilometer tal
        public void PrintCarDetails()
        {

            Console.WriteLine("Brand".PadRight(15) + "|" + "Model".PadRight(15) + "|" + "Year".PadRight(15) + "|" + "Mileage".PadRight(15) + "|" + "FuelConsumption".PadLeft(15));
            Console.WriteLine("---------------|---------------|---------------|---------------|---------------");
            Console.WriteLine(Brand.PadRight(15) + "|" + Model.PadRight(15) + "|" + Year.ToString().PadRight(15) + "|" + Odometer.ToString().PadRight(15) + "|" + FuelConsumption.ToString().PadLeft(15));

            //  PRØV AT RETURNERE EN STRING MED ALLE DE DETALJERE SOM KAN FORMATERES I PROGRAMMET

            //Console.WriteLine("{0} {1} fra {2} med {3} - brændsstofforbrug på ca {4} km/l.", Brand, Model, Year.ToString(), Mileage.ToString(), FuelConsumption.ToString());
        }


        public double CalculateFuelUsed()
        {
            if (KmPerLiter <= 0)
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
               FuelUsed = Distance / KmPerLiter;
            }
            return FuelUsed;
            
        }


        // Udregner prisen for en tur 
        public double CalculateTripPrice()
        {
            return Math.Round(CalculateFuelUsed()* LiterPrice, 2);     //rounded to 2 decimals
           
            //Console.WriteLine("Total pris for en køretur på {0} er {1} kr", distance, tripPrice);
        }


        public void Drive(Trip newTrip)
        {
            Odometer += (int)newTrip.Distance;
            _trips.Add(newTrip);
        }

        public List<Trip> PrintAllTrips()
        {
            return new List<Trip>(_trips);

            //foreach (var trip in _trips)                          //DET KAN MAN GODT MEN HUSK SIMPLITET - KAN BRUGES cw I MAIN
            //{
            //    Console.WriteLine(trip.PrintTripDetails());       //Skriv parametre som skal udskrives i consolen ift TRIP
            //}
        }


        public void Drive1(Trip newTrip)
        {
            if (!IsEngineOn)
            { 
                Odometer += (int)newTrip.Distance;
                double tripPrice = CalculateTripPrice();
            }


            //Drive-metoden vil være ansvarlig for
            //      at kontrollere om motoren er tændt,
            //      beregne brændstofforbrug og turpris, og
            //      opdatere bilens kilometerstand (Odometer).
            //Denne metode kan ligge i Car-klassen, mens den tager oplysninger fra Trip-objektet som parameter.
        }



        //GetTripsByDate-metoden skal gennemgå alle Trip-objekter og finde de ture, der blev gennemført på en specifik dato.
        //Denne metode skal ligge i Car-klassen og benytte et loop til at søge gennem alle ture.

        public List<Trip> GetTripsByDate(string date)       //vi arbejder med TRIP klassen derfor er datatypen i metoden LIST
        {
            List<Trip> tripsByDate = new List<Trip>();      //instansieriser en nye liste for at gemme de ture med den angivne dato

            date = Convert.ToDateTime(date).ToShortDateString();    //instansieriser = husk at convertere til dato


            foreach (Trip trip in _trips)                           //foreach loop for at tjekke hver trip om den indeholder datoen
            {
                if (trip.TripDate.ToShortDateString() == date)
                {
                    tripsByDate.Add(trip);                          //gem turen til en anden liste
                }

            }

            return tripsByDate;                                     //returner en liste med datoerne når metoden er kaldt ud i MAIN

        }


        



    }
    public enum FuelType        // enum for Fuel Type
    {
             BENZIN,                        // find en løsning til at sætte alle bogstaver TO LOWER og den førstebogstav til TO UPPER...
             Diesel,
             Hybrid,
             Elektrisk
    }

    public enum GearType        // enum for Gear Type
    {
        Automatisk,
        Manual
    }

//  OPGAVE 6 


}


