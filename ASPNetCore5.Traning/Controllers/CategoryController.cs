using ASPNetCore5.Traning.Data;
using ASPNetCore5.Traning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore5.Traning.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var categories = _db.Category;
            return View(categories);
        }

        //GET - CREATE 
        public IActionResult Create()
        {
            return View();
        }

        //Post - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if(id != null && id == 0)
            {
                return NotFound();
            }

            var category = _db.Category.Find(id);
            if (category == null) 
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        //Get - Delete
        public IActionResult Delete(int? id)
        {
            if (id != null && id == 0)
            {
                return NotFound();
            }

            var category = _db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _db.Category.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            _db.Category.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
