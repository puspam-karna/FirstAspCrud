using FirstApp.Models;
using FirstApp.mydatabase;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CatagoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Catagory> objCatagoryList=_db.Catagories.ToList();
            return View(objCatagoryList);
        }
        //CreateGET
        public IActionResult Create()
        {
            
            return View();
        }

        //CreatePOST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "DisplayOrder and Name cannot be same");

            }
            if (ModelState.IsValid)
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Catagory created successfully";

                return RedirectToAction("Index");
            }
            else { return View(obj); }
        }

        //editGET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _db.Catagories.Find(id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }

            return View(catagoryFromDb);
        }

        //editPOST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "DisplayOrder and Name cannot be same");

            }
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Catagory edited successfully";


                return RedirectToAction("Index");
            }
            else { return View(obj); }
        }

        //deleteGET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _db.Catagories.Find(id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }

            return View(catagoryFromDb);
        }

        //editPOST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Catagories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Catagories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Catagory deleted successfully";

            return RedirectToAction("Index");
           
        }


    }
}

