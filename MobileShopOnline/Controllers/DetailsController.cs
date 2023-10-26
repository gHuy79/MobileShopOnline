    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MobileShopOnline.Models;
using System.Data.Entity;

namespace MobileShopOnline.Controllers
{
    public class DetailsController : Controller
    {
        MobileShopOnlineEntities db = new MobileShopOnlineEntities();
        public ActionResult Index(int id)
        {
            

            ViewBag.ProdDetails = db.Products.FirstOrDefault(n => n.ProductID == id);
            int thisProdCategories = db.Products.FirstOrDefault(n => n.ProductID == id).CategoryID;

            ViewBag.ThisProdCategories = db.Categories.FirstOrDefault(n => n.CategoryID == thisProdCategories);

            ViewBag.ProductList = (from p in db.Products where p.CategoryID == thisProdCategories && p.ProductID != id select p).ToList().Take(10);
            
            
            return View();
        }
    }
}