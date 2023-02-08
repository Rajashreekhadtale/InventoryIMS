using InventoryIMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InventoryIMS.Controllers
{
    public class EditsController : Controller
    {
        private readonly dbSampleContext _db;
        public EditsController(dbSampleContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<TblProduct> Products = _db.TblProducts.ToList();
            return View(Products);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(TblProduct Product)
        {
            if (ModelState.IsValid)
            {

                _db.TblProducts.Add(Product);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TblProduct Product = _db.TblProducts.Single(x => x.Product_Id == id);
            return View(Product);

        }



        [HttpPost]

        public IActionResult Edit(TblProduct Product)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(Product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Product);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            TblProduct Product = _db.TblProducts.Single(x => x.Product_Id == id);
            return View(Product);
        }


        [HttpPost]
        [ActionName("Delete")]

        public IActionResult Delete(int? id)
        {
            TblProduct Product = _db.TblProducts.Single(x => x.Product_Id == id);
            _db.TblProducts.Remove(Product);
           _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            TblProduct Product = new TblProduct();
            Product = _db.TblProducts.Single(x => x.Product_Id == id);
            return View(Product);
        }
    }
}

    

