using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace CarApp
{
    public class Trip
    {
        private double _distance;                                                               //PRIVAT PROPERTIES
        private DateTime _tripDate;
        private DateTime _startTime;
        private DateTime _endTime;
        private double _tripPrice;
        private double _literPrice;

        public double Distance { get { return _distance; } set { _distance = value; } }                                                                 //GETTER SETTER FOR EACH PROPERTIES


        public DateTime TripDate { get { return _tripDate; } set { _tripDate = value; } }


        public DateTime StartTime { get { return _startTime; } set { _startTime = value; } }


        public DateTime EndTime { get { return _endTime; } set { _endTime = value; } }

        public double TripPrice { get { return _tripPrice; } set { _tripPrice = value; } }

        public double LiterPrice { get { return _literPrice; } set { _literPrice = value; } }



        /*Metoder og Constructor*/



        public Trip(double distance, DateTime tripDate, DateTime startTime, DateTime endTime)           //CONSTRUCTOR
        {
            Distance = distance;
            TripDate = tripDate;
            StartTime = startTime;
            EndTime = endTime;
        }


        public TimeSpan TripDuration()                                                      //metode for afregning af turens varighed
        {
            return EndTime - StartTime;
        }



        public double CalculateFuelUsed(double kmPerLiter)                                   //metode for afregning af brugt mængde brændstoff under turen 
        {
            try
            {
                if (kmPerLiter <= 0)
                {
                    throw new DivideByZeroException("Invalid indtastning");
                }

                double FuelUsed = Distance / kmPerLiter;
                return FuelUsed;


            }
            catch (DivideByZeroException dpz)                                               /*Exception - Divide  By  Zero*/
            {
                Console.Write("Den intastede værdi skal være over null", dpz.Message);
                return 0;                                                                   /* Programmet crasher hvis man ikke angive en "double" til at returnerer pga metodens datatype*/
            }
            finally
            {
                Console.WriteLine("Køretur forbrug afregnet");
            }

        }



        public double CalculateTripPrice(double literPrice, double kmPerLiter)              //metode for afregning af turens omkostning
        {
            try
            {
                if (kmPerLiter <= 0)
                {
                    throw new DivideByZeroException("Invalid indtastning");
                }
                TripPrice = (Distance / kmPerLiter) * literPrice;
                return TripPrice;

                /* en anden måde at lave en afregning med afrundning til 2 decimaler
                double tripPrice = Math.Round(((_distance / kmPerLiter) * literPrice), 2);     //rounded to 2 decimals     */



            }
            catch (DivideByZeroException dpz)                                                /*Exception - Divide  By  Zero*/
            {
                Console.Write("Den intastede værdi skal være over null", dpz.Message);
                return 0;                                                                   /* Programmet crasher hvis man ikke angive en "double" til at returnerer pga metodens datatype*/
            }
            finally
            {
                Console.WriteLine("Turomkostning afregnet");
            }
        }


        public string PrintTripDetails()                                                    // metode for at printe alle turens detaljer
        {
            return  /*$"Køreturdetaljere:" + 
                    $"\nAfstand".PadRight(15) + " | " + "Dato".PadRight(15) + " | " + "Starttidspunkt".PadRight(15) + " | " + "Sluttidspunkt".PadRight(15) + " | " + "Trip Duration".PadRight(15) +*/
                    $"\n{Distance.ToString().PadRight(15)}  | {TripDate.ToShortDateString().PadRight(15)} | {StartTime.ToShortTimeString().PadRight(15)} | {EndTime.ToShortTimeString().PadRight(15)} | {TripDuration().ToString().PadRight(15)}";
            ;
        }

        public string HeadPrintTripDetails()
        {
            return
               $"Køreturdetaljere:" +
               $"\nAfstand".PadRight(15) + " | " + "Dato".PadRight(15) + " | " + "Starttidspunkt".PadRight(15) + " | " + "Sluttidspunkt".PadRight(15) + " | " + "Trip Duration".PadRight(15) +
               $"\n--------------- | --------------- | --------------- | --------------- | ---------------";
        }




        public override string ToString()                           //override ad ToString metode så man lave en trip objekt til en streng
        {
            return $"Tur detaljer : {Distance.ToString()} - {TripDate.ToShortDateString()} - {StartTime.ToShortTimeString} - {EndTime.ToShortTimeString}";
        }


        public static Trip FromString(string data)
        {
            string[] parts = data.Split('-');                       // Opdeler strengen baseret på komma
            


            double distance = double.Parse(parts[0]);                   // Konverterer første del til Distance
            DateTime tripDate = DateTime.Parse(parts[1]);                // Anden del er Køreturens dato
            DateTime startTime = DateTime.Parse(parts[2]);               // Tredje del er køreturens starttidspunkt 
            DateTime endTime = DateTime.Parse(parts[3]);                 // Fjerde del er køreturens sluttidspunkt

            Trip trip = new Trip(distance, tripDate, startTime, endTime);
            return trip;
            
        }


    }
}