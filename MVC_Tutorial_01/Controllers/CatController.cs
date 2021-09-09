using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Tutorial_00.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Tutorial_00.Controllers
{
    public class CatController : Controller
    {
        private static readonly List<Cat> _cats = new List<Cat>()
        {
            new Cat() { PetId = 1, Age = 5, Name = "橘貓"},
            new Cat() { PetId = 2, Age = 5, Name = "摺耳貓"},
            new Cat() { PetId = 3, Age = 5, Name = "花貓"},
        };

        // GET: CatController
        public ActionResult Index()
        {
            return View(_cats);
        }

        // GET: CatController/Details/5
        public ActionResult Details(int id)
        {
            var cat = _cats.FirstOrDefault(x => x.PetId == id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // GET: CatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cat model)
        {
            try
            {
                _cats.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = _cats.FirstOrDefault(x => x.PetId == id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: CatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cat model)
        {
            try
            {
                var cat = _cats.FirstOrDefault(x => x.PetId == model.PetId);
                if (cat == null)
                {
                    return NotFound();
                }
                cat.Name = model.Name;
                cat.Age = model.Age;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var cat = _cats.FirstOrDefault(x => x.PetId == id);
                if (cat == null)
                {
                    return NotFound();
                }

                _cats.Remove(cat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
