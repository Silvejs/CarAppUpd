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

        public void SaveCar(Car car)                        /*FRA OPGAVESÆTET UGE 7 - EXCEPTIONS*/
        {
            StreamWriter writer = null;                                     // USING mangler her....hvorfor ???
            try
            {
                writer = new StreamWriter(FilePathCars, append: true);
                writer.WriteLine(car.ToString());
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Fejl under skrivning: {ex.Message}");
            }
            finally
            {
                writer?.Close();                                            //hvorfor ? - hvad laver Close funktionen
                Console.WriteLine("Ressource frigivet.");
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

        public List<Car> LoadCarsWithExcep()
        {
            List<Car> cars = new List<Car>();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(FilePathCars);
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    Car car = Car.FromString(line);                         // Assuming Car has a static FromString method or constructor
                    cars.Add(car);
                }

            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("Fil er ikke til at findes!!!");
                Console.WriteLine($"Fejl under læsning: {fnf.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl under læsning: {ex.Message}");
            }
            finally
            {
                reader?.Close();
                Console.WriteLine("File Not Found");
            }
            return cars;
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

