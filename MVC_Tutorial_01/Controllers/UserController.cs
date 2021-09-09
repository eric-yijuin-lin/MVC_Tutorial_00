using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Tutorial_00.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Tutorial_00.Controllers
{
    public class UserController : Controller
    {
        private static readonly List<User> _users = new List<User>()
        {
            new User() {UserId = 1, UserName = "Alice", Email = "alice@test.net"},
            new User() {UserId = 2, UserName = "Bob", Email = "bob@test.net"},
            new User() {UserId = 3, UserName = "Cathy", Email = "cathy@test.net"},
        };

        // GET: UserController
        public ActionResult Index()
        {
            return View(_users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = _users.FirstOrDefault(x => x.UserId == id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            try
            {
                _users.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
            var user = _users.FirstOrDefault(x => x.UserId == model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                user.UserName = model.UserName;
                user.Email = model.Email;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(x => x.UserId == id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = _users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _users.Remove(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
