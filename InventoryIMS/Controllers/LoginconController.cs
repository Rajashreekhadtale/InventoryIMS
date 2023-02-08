using InventoryIMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace InventoryIMS.Controllers
{
    public class LoginconController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            TblLogin login = new TblLogin();

            return View(login);
        }


        [HttpPost]

        public IActionResult Login(TblLogin login)
        {

            dbSampleContext sampleContext = new dbSampleContext();

            var status = sampleContext.TblLogins.Where(m => m.Username == login.Username && m.Password == login.Password).FirstOrDefault();

            if (status != null)

            {

                ViewBag.Message = "Success full login";

                HttpContext.Session.SetString("Username",login.Username);
                

                return RedirectToAction("Index", "Edits");
            }

            else

            {

                ViewBag.Message = "Invalid login details";
            }

            return View(login);


        }
        [HttpPost]
        public IActionResult Logout()
        {
           
            return RedirectToAction("Product", "ProductCon");
           
           
        }
    }
}
















