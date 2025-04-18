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
        private string _nummerplade;
        private string _date;








        public string Brand { get { return _brand; } set { _brand = value;}}

        public string Model { get { return _model; } set { _model = value; } }        // getter setter for MODEL property
       

        public int Årgang { get { return _årgang; } set { _årgang = value; } }            // getter setter for YEAR property
       

        public int Odometer { get { return _odometer; } set { _odometer = value; } }                                // getter setter for MILEAGE property


        public double Distance { get { return _distance; } set { _distance = value; } }                            // getter setter for DISTANCE property


        public bool IsEngineOn { get { return _isEngineOn; } set { _isEngineOn = value; } }                              //bool IsEngineOn property

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
            FuelType = fuelType;
            GearType = gearType;
            Nummerplade = nummerplade;

        }



       
                                        
        public string PrintCarDetails()                                     //Print Car Details i consollen -> nu med opdateret kilometer tal
        {

            return $"{Brand.PadRight(15)} | {Model.PadRight(15)} | {Årgang.ToString().PadRight(15)} | {Odometer.ToString().PadRight(15)} | {Nummerplade.PadRight(15)} | ";
                   
                   
       
        }

        /*public string HeadPrintCarDetails()                               //Den skal være i Car Class
        {

            return "Brand".PadRight(15) + " | " + "Model".PadRight(15) + " | " + "Year".PadRight(15) + " | " + "Odometer".PadRight(15) + " | " + "Nummerplade".PadRight(15) + " | " +
                   "\n--------------- | --------------- | --------------- | --------------- | ---------------";
        }*/
            



        public void Drive(Trip newTrip)
        {
            if (true)
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
            return _trips;



            //foreach (var trip in _trips)                          //DET KAN MAN GODT MEN HUSK SIMPLITET - KAN BRUGES cw I MAIN
            //{
            //    Console.WriteLine(trip.PrintTripDetails());       //Skriv parametre som skal udskrives i consolen ift TRIP
            //}
        

        //GetTripsByDate-metoden skal gennemgå alle Trip-objekter og finde de ture, der blev gennemført på en specifik dato.
        //Denne metode skal ligge i Car-klassen og benytte et loop til at søge gennem alle ture.
        }


        public List<Trip> GetTripsByDate(string date)                       //vi arbejder med TRIP klassen derfor er datatypen i metoden LIST
        {
            List<Trip> tripsByDate = new List<Trip>();              //instansieriser en nye liste for at gemme de ture med den angivne dato

                


            foreach (Trip trip in _trips)                           //foreach loop for at tjekke hver trip om den indeholder datoen
            {
                if (trip.TripDate.ToShortDateString() == date)
                {
                    tripsByDate.Add(trip);                          //gem turen til en anden liste
                }

            }

            return tripsByDate;                                     //returner en liste med datoerne når metoden er kaldt ud i MAIN

        }


        public bool Palindrome(int odometer)                                /* Er odometeren en Palindrome? */
        {
            Odometer = odometer;
            int remainder;
            int reversedNumber = 0 ;

            if (Odometer > 0)
            {
                remainder = odometer % 10;
                reversedNumber = reversedNumber * 10 + remainder;
                odometer /= 10;
            }

            return odometer == reversedNumber;
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


