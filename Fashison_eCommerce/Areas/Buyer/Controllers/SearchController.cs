using Fashison_eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashison_eCommerce.Areas.Buyer.Controllers
{
    public class SearchController : Controller
    {
        // GET: Buyer/Search

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            try
            {
                string name = Request.Form["name"];
                int id = Convert.ToInt32(Request.Form["mainType"]);

                Search(name, id);
                return View();
            }
            catch
            {
                return Redirect("/");
            }
            
        }
        
        public ActionResult Search(string name, int typeid)
        {
            //if (name != null && typeid != 0)
            //{
            ProductClient PC = new ProductClient();
            ViewBag.Product = PC.search(typeid, name);
            try
            {
                ViewBag.Count = PC.search(typeid, name).Count();
            }
            catch
            {
                ViewBag.Count = 0;
                return Redirect("/");
            }
                
            //    return View();
            //}
            return View();
        }
    }
}