using Microsoft.AspNetCore.Mvc;
using Testing.Data;
using Testing.Models;

namespace Testing.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DesplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DesplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
           
            Category? CategoryFromDb = _db.Categories.Find(id);
            //Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? CategoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            
            
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj); 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? CategoryFromDb = _db.Categories.Find(id);
            //Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? CategoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();


            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
