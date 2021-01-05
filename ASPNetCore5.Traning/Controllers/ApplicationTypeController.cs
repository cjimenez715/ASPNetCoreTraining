using ASPNetCore5.Traning.Data;
using ASPNetCore5.Traning.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore5.Traning.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var applitacionTypes = _db.ApplicationType;
            return View(applitacionTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            _db.ApplicationType.Add(applicationType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if (id != null && id == 0)
            {
                return NotFound();
            }

            var category = _db.ApplicationType.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(applicationType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }


        //Get - Delete
        public IActionResult Delete(int? id)
        {
            if (id != null && id == 0)
            {
                return NotFound();
            }

            var applicationType = _db.ApplicationType.Find(id);
            if (applicationType == null)
            {
                return NotFound();
            }
            return View(applicationType);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var applicationType = _db.ApplicationType.Find(id);
            if (applicationType == null)
            {
                return NotFound();
            }
            _db.ApplicationType.Remove(applicationType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
