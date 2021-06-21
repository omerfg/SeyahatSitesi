using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWebSite.Models.Siniflar;
namespace TravelWebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context db = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            db.Blogs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b = db.Blogs.Find(id);
            db.Blogs.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = db.Blogs.Find(id);
            return View("BlogGetir",bl);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = db.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlars = db.Yorumlars.ToList();
            return View(yorumlars);
        }

        public ActionResult YorumSil(int id)
        {
            var y = db.Yorumlars.Find(id);
            db.Yorumlars.Remove(y);
            db.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

    }
}