using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAppClassTrip;
using Microsoft.VisualBasic;

namespace CarAppClassCar
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
        public void Drive(bool isEngineOn, double distance)
        {
            if (!isEngineOn)
            {
                Console.WriteLine("Tænd bilen");
            }
            else
            {
                Odometer += Convert.ToInt32(distance);
                Console.WriteLine("Opdateret odometer: {0}", Odometer);
            }

        }

        

            //Print Car Details i consollen -> nu med opdateret kilometer tal
        public void PrintCarDetails()
        {

            Console.WriteLine("Brand".PadRight(15) + "|" + "Model".PadRight(15) + "|" + "Year".PadRight(15) + "|" + "Mileage".PadRight(15) + "|" + "FuelConsumption".PadLeft(15));
            Console.WriteLine("---------------|---------------|---------------|---------------|---------------");
            Console.WriteLine(Brand.PadRight(15) + "|" + Model.PadRight(15) + "|" + Year.ToString().PadRight(15) + "|" + Odometer.ToString().PadRight(15) + "|" + FuelConsumption.ToString().PadLeft(15));

            //  PRØV AT RETURNERE EN STRING MED ALLE DE DETALJERE SOM KAN FORMATERES I PROGRAMMET

            //Console.WriteLine("{0} {1} fra {2} med {3} - brændsstofforbrug på ca {4} km/l.", Brand, Model, Year.ToString(), Mileage.ToString(), FuelConsumption.ToString());
        }





        // Udregner prisen for en tur 
        //public void CalculateTripPrice(double distance, double literPrice)
        //{
          //  double tripPrice = Math.Round(((distance / FuelConsumption) * literPrice), 2);     //rounded to 2 decimals


            //Console.WriteLine("Total pris for en køretur på {0} er {1} kr", distance, tripPrice);
        //}


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
        
    }
    public enum FuelType        // enum for Fuel Type
    {
             Benzin,
             Diesel,
             Hybrid,
             Elektrisk
    }

    public enum GearType        // enum for Gear Type
    {
        Automatisk,
        Manual
    }




}


