using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Display Interface on Home
        public IActionResult Index()
        {
            // Lấy danh sách các Category từ database
            List<Categories> objCategoriesList = _db.Categories.ToList();

            // Truyền danh sách Category tới view
            return View(objCategoriesList);
        }




        // Function :Create New Categories
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories obj) 
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }    
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Categories created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

   
        //Function :Update Categories
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categories? categoriesFromDb = _db.Categories.Find(id);
            //  Categories? categoriesFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //   Categories? categoriesFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault(); 


            if (categoriesFromDb == null)
            {
                return NotFound();
            }

            return View(categoriesFromDb);
        }



        [HttpPost]
        public IActionResult Edit(Categories obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Categories updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }





        //Function :Delete Object
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Categories? categoriesFromDb = _db.Categories.Find(id);
            //  Categories? categoriesFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //   Categories? categoriesFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault(); 


            if (categoriesFromDb == null)
            {
                return NotFound();
            }

            return View(categoriesFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Categories? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Categories deleted successfully";

            return RedirectToAction("Index");
        }
    }
}

