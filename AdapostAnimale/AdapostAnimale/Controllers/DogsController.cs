using AdapostAnimale.Models;
using AdapostAnimale.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdapostAnimale.Controllers
{
    public class DogsController : Controller
    {
        private DogRepository DogRepository;
        public DogsController()
        {
            DogRepository = DogRepository.Instance;
        }

        [HttpGet]
        public IActionResult List(Gender? gender, FurColor? color)
        {
            return View(DogRepository.GetDogs());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Dog());
        }
        [HttpPost]
        public IActionResult Create(Dog model)
        {
            if (ModelState.IsValid)
            {
                //List<Dog> myList = DogRepository.GetDogs();
                //model.myList[myList.Count - 1].ID + 1;
                model.ID = DogRepository.GetDogs().Max(x => x.ID) + 1;
                DogRepository.Add(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Dog dogToRead = DogRepository.GetDogs().Find(x => x.ID == id);
            return View(dogToRead);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Dog dogToEdit = DogRepository.GetDogs().Find(x => x.ID == id);
            return View(dogToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Dog model)
        {
            if (ModelState.IsValid)
            {
                var dogToEdit = DogRepository.GetDogs().Find(x => x.ID == model.ID);
                TryUpdateModelAsync(dogToEdit);
                return RedirectToAction("List");
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Dog dogToDelete = DogRepository.GetDogs().Find(x => x.ID == id);
            return View(dogToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Dog model)
        {
            var dogToDelete = DogRepository.GetDogs().Find(x => x.ID == model.ID);
            DogRepository.Delete(dogToDelete);
            return RedirectToAction("List");
        }
    }
}