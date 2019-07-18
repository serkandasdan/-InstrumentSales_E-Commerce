using EnstrumanSatis_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnstrumanSatis_MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        EnstrumanSatisEntities db = new EnstrumanSatisEntities();
        public ActionResult Index(int id) {

            List<Product> pList = db.Products.Where(x => x.CategoryID == id).ToList();
            return View(pList);
        }

        public ActionResult ProductDetails (int id)
        {
            
            ViewBag.CommentList = db.Comments.Where(x => x.ProductID == id).ToList();

            Product product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment,string UserName)
        {
            int UserID = db.User_.Where(x => x.UserName == UserName).Select(x => x.ID).FirstOrDefault();
            comment.UserID = UserID;
            comment.CreateDate = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("ProductDetails", new { id = comment.ProductID });
        }
    }
}