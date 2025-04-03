using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CarApp
{
    public class Trip
    {
        private double _distance;           //PRIVAT PROPERTIES
        private DateTime _tripDate;
        private DateTime _startTime;
        private DateTime _endTime;


        public double Distance             //GETTER SETTER FOR EACH PROPERTIES
        {
            get
            {
                return _distance;
            }
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

        public DateTime TripDate
        {
            get
            {
                return _tripDate;
            }
            set
            {
                if (value == DateTime.Now.Date)
                {
                    _tripDate = DateTime.Now.Date;
                }
            }
        }

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (value >= DateTime.Now)
                {
                    _startTime = DateTime.Now;
                }
            }
        }

        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if (value >= DateTime.Now)
                {
                    _endTime = value;
                }
            }
        }

        //CONSTRUCTOR
        public Trip(double distance, DateTime tripDate, DateTime startTime, DateTime endTime)
        {
            double Distance = distance;
            DateTime TripDate = tripDate;
            DateTime StartTime = startTime;
            DateTime EndTime = endTime;
        }


        public TimeSpan TripDuration()         //metode for afregning af turens varighed
        {
            return EndTime - StartTime;
        }



        public double CalculateFuelUsed(double kmPerLiter)          //metode for afregning af brugt mængde brændstoff under turen 
        {
            double tripFuelUsed = Distance / kmPerLiter;
            return tripFuelUsed;
        }



        public double CalculateTripPrice(double literPrice, double kmPerLiter)      //metode for afregning af turens omkostning
        {

            return (Distance / kmPerLiter) * literPrice;
        }

        public void PrintTripDetails()      // metode for at printe alle turens detaljer
        {
            Console.WriteLine("Køreturdetaljere; " + _distance.ToString() + " - " + TripDate.ToShortDateString() + " - " + StartTime.ToShortDateString() + " - " + EndTime.ToShortDateString());
        }
    }
}