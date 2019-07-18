using EnstrumanSatis_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnstrumanSatis_MVC_Project.Controllers
{
    public class CategoryController : Controller
    {
      
       EnstrumanSatisEntities db = new EnstrumanSatisEntities();
        public PartialViewResult Category()
        {
            List<Category> categories = db.Categories.ToList();
            return PartialView(categories);
        }

    }
}