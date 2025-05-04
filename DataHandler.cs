using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CarApp;

namespace CarAppUpd
{
    public class DataHandler        /* DataHandler Class for at får overblik over Filhåndtering - StreamWriter og StreamReader */
   

    {


        public static string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string folder = Path.Combine(projectPath, "Data");
        public static string FilePathCars = Path.Combine(folder, "Cars.txt");
        public string FilePath { get; set; }
        //public static string FilePathTrips = Path.Combine(folder, "Trips.txt");

        
        public List<Car> bilRegister = new List<Car>();
        //public List<Trip> tripsRegister = new List<Trip>();



        public DataHandler(string? filePathCars= null)
        {
            FilePath = filePathCars ?? FilePathCars;


            // Create directory if it doesn't exist
            string directory = Path.GetDirectoryName(FilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Create file if it doesn't exist
            if (!File.Exists(FilePath))
            {
                // Create an empty txt 
                File.WriteAllText(FilePath, "Cars.txt");

            }

           

          
        }
        


        public void SaveCars()                          // Metode til at gemme en liste af biler i en fil
        {   

            using (StreamWriter sw = new StreamWriter(FilePathCars, true))            // Åbner filen til skrivning
            {
                
                    foreach (var bil in bilRegister )
                    {
                        sw.WriteLine(bil.ToString());                       // Gemmer hver bil som en linje i filen
                    }
               
            }
        }

        /*public void SaveCar(Car car)                        FRA OPGAVESÆTET UGE 7 - EXCEPTIONS
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
        }*/



         public List<Car> LoadCars()                                 // Metode til at indlæse en liste af medarbejdere fra en fil
        {
            List<Car> cars = new List<Car>();

            using (StreamReader sr = new StreamReader(FilePathCars, true))            // Åbner filen til læsning
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
            bilRegister = cars;
            return cars;                                                    // Returnerer listen af medarbejdere
            
        }

        /*public List<Car> LoadCarsWithExcep()
        {
            List<Car> cars = new List<Car>();
           

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(FilePathCars, true);
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
        }*/






        /*public void SaveTrips()                          // Metode til at gemme en liste af biler i en fil
        {
            using (StreamWriter sw = new StreamWriter(FilePathTrips, true))            // Åbner filen til skrivning
            {
                List<Trip> trips = new List<Trip>();

                foreach (var trip in trips)
                {
                    sw.WriteLine(trip.ToString());                       // Gemmer hver bil som en linje i filen
                }

            }
        }


        public List<Trip> LoadTrips()                                 // Metode til at indlæse en liste af medarbejdere fra en fil
        {
           

            
            List<Trip> trips = new List<Trip>();
            string[] lines = File.ReadAllLines(FilePathTrips);
            if (File.Exists(FilePathTrips));

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

        */
    }


        

}

