using InventoryIMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryIMS.Controllers
{
    public class SalesController : Controller
    {
        private readonly dbSampleContext _db;

        public SalesController(dbSampleContext db)
        {
            _db = db;

        }

        [HttpGet]
        public IActionResult sale()
        {
            TblSale sale = new TblSale();

            dbSampleContext sampleContext = new dbSampleContext();
            ViewBag.ProductNavigation = new SelectList(sampleContext.TblProducts.ToList(), "Product_Id", "Product_Name");

            ViewBag.ProductId = new SelectList(_db.TblProducts, "Product_Id", "Name");


            return View(sale);
        }

        [HttpPost]
        public IActionResult Sale(TblSale sale)
        {
            dbSampleContext sampleContext = new dbSampleContext();
            sampleContext.Add(sale);

            sampleContext.SaveChanges();

            ViewBag.Message = "Product Receipt Generated";

            ViewBag.ProductNavigation = new SelectList(sampleContext.TblProducts.ToList(), "Product_Id", "Product_Name");

            return View(sale);
        }

        
        [HttpGet]
        public IActionResult Getdata(int ProductId)
        {
            var productPrice = _db.TblProducts.Where(x => x.Product_Id == ProductId).Select(x => x.Product_Price).FirstOrDefault();
            return Json(productPrice);
        }

       
        

    }
}
















