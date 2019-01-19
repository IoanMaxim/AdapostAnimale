using AdapostAnimale.Models;
using System;
using System.Collections.Generic;

namespace AdapostAnimale.Services
{
    public class CatRepository
    {
        private static List<Cat> cats = new List<Cat>();
        private static CatRepository instance;

        public CatRepository()
        {
        }

        public static CatRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CatRepository();
                    cats = InitializeList();
                }
                return instance;
            }
        }

        private static List<Cat> InitializeList()
        {
            List<Cat> cats = new List<Cat>();
            cats.Add(new Cat(1, "Bulinuta", new DateTime(2018, 08, 06), Gender.Female, FurColor.Yellow, "Radu", "radu@gmail.com"));
            cats.Add(new Cat(2, "Milo", new DateTime(2015, 11, 02), Gender.Male, FurColor.Yellow, "Fat Frumos", "fat.frumos@gmail.com"));
            cats.Add(new Cat(3, "Sisi", new DateTime(2013, 05, 16), Gender.Female, FurColor.White, "Praslea", "praslea.cel.voinic@yahoo.com"));
            cats.Add(new Cat(4, "Puma", new DateTime(2017, 11, 23), Gender.Male, FurColor.Yellow, "Mircea", "mircea.badea@ymail.com"));
            cats.Add(new Cat(5, "Aki", new DateTime(2018, 04, 12), Gender.Male, FurColor.Black, "Scufita Rosie", "scufita.rosie@gmail.com"));
            cats.Add(new Cat(6, "Mitza", new DateTime(2018, 10, 15), Gender.Male, FurColor.Black, "Hansel", "hansel@yahoo.com"));
            cats.Add(new Cat(7, "Mia", new DateTime(2018, 09, 18), Gender.Female, FurColor.White, "Grettel", "grettel@hotmail.com"));
            cats.Add(new Cat(8, "Nyla", new DateTime(2018, 06, 28), Gender.Female, FurColor.Black, "Diana", "diana@gmail.com"));
            cats.Add(new Cat(9, "Boss", new DateTime(2018, 05, 24), Gender.Male, FurColor.Black, "Raluca", "raluca@gmail.com"));
            return cats;
        }

        public List<Cat> GetCats()
        {
            return cats;
        }
        public void Add(Cat newCat)
        {
            cats.Add(newCat);
        }
        public void Delete(Cat model)
        {
            cats.Remove(model);
        }
    }
}
