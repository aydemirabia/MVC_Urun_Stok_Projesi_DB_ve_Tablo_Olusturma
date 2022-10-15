using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Urun_Stok_Blog.Models.EntityFramework;
namespace MVC_Urun_Stok_Blog.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MVC_Urun_Stok_OlusturmaEntities db = new MVC_Urun_Stok_OlusturmaEntities();
        public ActionResult Index(string p1)
        {
            var degerler = from d in db.tbl_musteriler select d;
            //eğer parametre boş değilse
            if (!string.IsNullOrEmpty(p1))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p1));
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tbl_musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tbl_musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.tbl_musteriler.Find(id);
            db.tbl_musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.tbl_musteriler.Find(id);
            return View("MusteriGuncelle", musteri);
        }

        public ActionResult Guncelle(tbl_musteriler p1)
        {
            var musteri = db.tbl_musteriler.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}