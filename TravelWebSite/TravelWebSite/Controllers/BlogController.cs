using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebSite.Models.Siniflar;

namespace TravelWebSite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context db = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            // var degerler = db.Blogs.ToList();
            by.Deger1 = db.Blogs.ToList();
            // by.Deger3 = db.Blogs.Take(3).ToList();
            by.Deger3 = db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
    
        public ActionResult BlogDetay(int id)
        {
            // var blogbull = db.Blogs.Where(x => x.Id == Id).ToList();
            by.Deger1 = db.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = db.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            db.Yorumlars.Add(y);
            db.SaveChanges();
            return PartialView();
        }

    }
}