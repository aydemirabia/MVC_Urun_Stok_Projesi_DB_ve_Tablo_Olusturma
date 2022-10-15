using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Urun_Stok_Blog.Models.EntityFramework;
namespace MVC_Urun_Stok_Blog.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVC_Urun_Stok_OlusturmaEntities db = new MVC_Urun_Stok_OlusturmaEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        public ActionResult YeniUrun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(tbl_urunler p1)
        {
            var ktg = db.tbl_kategoriler.Where(m => m.KATEGORIID == p1.tbl_kategoriler.KATEGORIID).FirstOrDefault();
            p1.tbl_kategoriler = ktg;
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YeniUrun(tbl_urunler p1)
        {
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(tbl_urunler p1)
        {
            var urun = db.tbl_urunler.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            var ktg = db.tbl_kategoriler.Where(m => m.KATEGORIID == p1.tbl_kategoriler.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            urun.URUNFIYAT = p1.URUNFIYAT;
            urun.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}