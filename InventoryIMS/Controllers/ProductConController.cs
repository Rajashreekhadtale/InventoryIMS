using InventoryIMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InventoryIMS.Controllers
{
    public class ProductConController : Controller
    {
        private readonly dbSampleContext _db;

        public ProductConController(dbSampleContext db)
        {
            _db = db;

        }
        [HttpGet]
        public IActionResult Product()
        {
            var getrecords = _db.TblProducts.ToList();

            List<TblProduct> tblProducts = new List<TblProduct>();

            foreach (var item in getrecords)
            {



                var tblProduct = new TblProduct()
                {
                    Product_Id = item.Product_Id,
                    Product_Name = item.Product_Name,
                    Product_Price = item.Product_Price,
                    Product_Qty = item.Product_Qty
                };
                tblProducts.Add(tblProduct);
            };

            return View(tblProducts);
        }
    }
}



