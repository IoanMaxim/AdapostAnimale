using AdapostAnimale.Models;
using AdapostAnimale.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdapostAnimale.Controllers
{
    public class CatsController : Controller
    {
        private CatRepository catRepository;
        public CatsController()
        {
            catRepository = CatRepository.Instance;
        }

        [HttpGet]
        public IActionResult List(Gender? gender, FurColor? color)
        {
            //var cats = PopulateList();
            //if (gender.HasValue)
            //{
            //    cats = cats.Where(x => x.Gender == gender.Value).ToList();
            //}
            //if (color.HasValue)
            //{
            //    cats = cats.Where(x => x.FurColor == color.Value).ToList();
            //}
            return View(catRepository.GetCats());
        }
        //private List<Cat> PopulateList()
        //{
        //    List<Cat> cats = new List<Cat>();
        //    cats.Add(new Cat(1, "Bulinuta", Gender.Female, FurColor.Yellow, "Radu"));
        //    cats.Add(new Cat(2, "Milo", Gender.Male, FurColor.Yellow, "Fat Frumos"));
        //    cats.Add(new Cat(3, "Sisi", Gender.Female, FurColor.White, "Praslea"));
        //    cats.Add(new Cat(4, "Puma", Gender.Male, FurColor.Yellow, "Mircea"));
        //    cats.Add(new Cat(5, "Aki", Gender.Male, FurColor.Black, "Scufita Rosie"));
        //    cats.Add(new Cat(6, "Mitza", Gender.Male, FurColor.Black, "Hansel"));
        //    cats.Add(new Cat(7, "Mia", Gender.Female, FurColor.White, "Grettel"));
        //    cats.Add(new Cat(8, "Nyla", Gender.Female, FurColor.Black, "Diana"));
        //    cats.Add(new Cat(9, "Boss", Gender.Male, FurColor.Black, "Raluca"));
        //    return cats;
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cat());
        }
        [HttpPost]
        public IActionResult Create(Cat model)
        {
            if (ModelState.IsValid)
            {
                //List<Cat> myList = catRepository.GetCats();
                //model.myList[myList.Count - 1].ID + 1;
                model.ID = catRepository.GetCats().Max(x => x.ID) + 1;
                catRepository.Add(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Cat catToRead = catRepository.GetCats().Find(x => x.ID == id);
            return View(catToRead);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cat catToEdit = catRepository.GetCats().Find(x => x.ID == id);
            return View(catToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Cat model)
        {
            if (ModelState.IsValid)
            {
                var catToEdit = catRepository.GetCats().Find(x => x.ID == model.ID);
                TryUpdateModelAsync(catToEdit);
                return RedirectToAction("List");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Cat catToDelete = catRepository.GetCats().Find(x => x.ID == id);
            return View(catToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Cat model)
        {
            var catToDelete = catRepository.GetCats().Find(x => x.ID == model.ID);
            catRepository.Delete(catToDelete);
            return RedirectToAction("List");
        }
    }
}