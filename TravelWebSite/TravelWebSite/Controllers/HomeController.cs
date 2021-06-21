using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebSite.Models.Siniflar;
namespace TravelWebSite.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Blogs.Take(8).ToList();
            return View(degerler);
        }
        public PartialViewResult Partial1()
        {
            var degerler = db.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger = db.Blogs.Where(x => x.ID == 3).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial3()
        {
            var deger = db.Blogs.Take(10).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial4()
        {
            var deger = db.Blogs.Take(3).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial5()
        {
            var deger = db.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }

    }
}