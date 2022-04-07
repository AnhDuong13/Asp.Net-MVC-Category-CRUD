using Bulky_Book.Data;
using Bulky_Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_Book.Controllers
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
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Create Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            var catgoryFromDb = _db.Categories.Find(id);
            if(catgoryFromDb == null)
            {
                return NotFound();
            }
            return View(catgoryFromDb);

        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edit Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catgoryFromDb = _db.Categories.Find(id);
            if (catgoryFromDb == null)
            {
                return NotFound();
            }
            return View();

        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
