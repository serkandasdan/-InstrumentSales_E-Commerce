using EnstrumanSatis_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnstrumanSatis_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
       
        EnstrumanSatisEntities db = new EnstrumanSatisEntities();

        [HttpPost]
        public ActionResult Index(string search)
        {
         
           // SqlParameter[] param = new SqlParameter[]
           //{
           //    new SqlParameter("@search",search??(object)DBNull.Value)
           //};
           // List<Product> data = db.Database.SqlQuery<Product>("GetProductBySearch @search", param).ToList();

            ViewBag.Product = db.Products.Where(x => x.ProductName.Contains(search)).ToList();
            return RedirectToAction("Home", "Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Product> product = db.Products.ToList();
            return View(product);
        }
    }
}