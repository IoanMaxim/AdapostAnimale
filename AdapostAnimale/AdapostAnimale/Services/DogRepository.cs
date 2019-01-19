using AdapostAnimale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdapostAnimale.Services
{
    public class DogRepository
    {
        private static List<Dog> dogs = new List<Dog>();
        private static DogRepository instance;

        public DogRepository()
        {
        }

        public static DogRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DogRepository();
                    dogs = InitializeList();
                }
                return instance;
            }
        }

        private static List<Dog> InitializeList()
        {
            List<Dog> dogs = new List<Dog>();
            dogs.Add(new Dog(1, "Roro", new DateTime(2018, 08, 06), Gender.Male, FurColor.Yellow, "Daniel", "daniel@gmail.com"));
            dogs.Add(new Dog(2, "Raff", new DateTime(2015, 11, 02), Gender.Male, FurColor.White, "Praslea", "praslea.cel.voinic@yahoo.com"));
            dogs.Add(new Dog(3, "Berna", new DateTime(2013, 05, 16), Gender.Female, FurColor.White, "Hansel", "hansel@yahoo.com"));
            dogs.Add(new Dog(4, "Sherry", new DateTime(2018, 09, 18), Gender.Female, FurColor.Yellow, "Raluca", "raluca@gmail.com"));
            dogs.Add(new Dog(5, "Ben", new DateTime(2018, 04, 12), Gender.Male, FurColor.Black, "Diana", "diana@gmail.com"));
            dogs.Add(new Dog(6, "Ariss", new DateTime(2018, 10, 15), Gender.Female, FurColor.White, "Grettel", "grettel@hotmail.com"));
            dogs.Add(new Dog(7, "Rony", new DateTime(2018, 06, 28), Gender.Male, FurColor.Black, "Mircea", "mircea.badea@ymail.com"));
            dogs.Add(new Dog(8, "Moshu", new DateTime(2017, 11, 23), Gender.Male, FurColor.Yellow, "Fat Frumos", "fat.frumos@gmail.com"));
            dogs.Add(new Dog(9, "Tzuspik", new DateTime(2018, 09, 18), Gender.Female, FurColor.Yellow, "Radu", "radu@gmail.com"));
            return dogs;
        }

        public List<Dog> GetDogs()
        {
            return dogs;
        }
        public void Add(Dog newDog)
        {
            dogs.Add(newDog);
        }
        public void Delete(Dog model)
        {
            dogs.Remove(model);
        }
    }
}
