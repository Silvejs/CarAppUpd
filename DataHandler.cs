using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarApp;

namespace CarAppUpd
{
    public class DataHandler        /* DataHandler Class for at får overblik over Filhåndtering - StreamWriter og StreamReader */
   

    {
        public string FilePathCars { get; set; } // Sti til filen, der gemmer data
        public string FilePathTrips { get; set; }


        public DataHandler(string filePathCars, string filePathTrips )
        {


            FilePathCars = filePathCars; // Sætter filstien ved oprettelse af DataHandler
            FilePathTrips = filePathTrips;   
            
        }

        


        public void SaveCars(List<Car> cars)                          // Metode til at gemme en liste af biler i en fil
        {
            using (StreamWriter sw = new StreamWriter(FilePathCars))            // Åbner filen til skrivning
            {
                
                    foreach (var bil in cars )
                    {
                        sw.WriteLine(bil.ToString());                       // Gemmer hver bil som en linje i filen
                    }
               
            }
        }

        
        public List<Car> LoadCars()                                 // Metode til at indlæse en liste af medarbejdere fra en fil
        {
            List<Car> cars = new List<Car>();

            using (StreamReader sr = new StreamReader(FilePathCars))            // Åbner filen til læsning
            {
                string line;
                while ((line = sr.ReadLine()) != null)                      // Læser hver linje i filen
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        cars.Add(Car.FromString(line));                     // Opretter en Employee fra linjen og tilføjer til listen
                    }
                }
            }

            return cars;                                                    // Returnerer listen af medarbejdere
        }

        public void SaveTrips(List<Trip> trips)                          // Metode til at gemme en liste af biler i en fil
        {
            using (StreamWriter sw = new StreamWriter(FilePathTrips))            // Åbner filen til skrivning
            {

                foreach (var trip in trips)
                {
                    sw.WriteLine(trip.ToString());                       // Gemmer hver bil som en linje i filen
                }

            }
        }


        public List<Trip> LoadTrips()                                 // Metode til at indlæse en liste af medarbejdere fra en fil
        {
            List<Trip> trips = new List<Trip>();

            using (StreamReader sr = new StreamReader(FilePathTrips))            // Åbner filen til læsning
            {
                string line;
                while ((line = sr.ReadLine()) != null)                      // Læser hver linje i filen
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        trips.Add(Trip.FromString(line));                     // Opretter en Employee fra linjen og tilføjer til listen
                    }
                }
            }

            return trips;                                                    // Returnerer listen af medarbejdere
        }
    }




}

