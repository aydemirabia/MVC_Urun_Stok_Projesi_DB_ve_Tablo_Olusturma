using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Urun_Stok_Blog.Models.EntityFramework;
using PagedList;
using PagedList.Mvc;
namespace MVC_Urun_Stok_Blog.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MVC_Urun_Stok_OlusturmaEntities db = new MVC_Urun_Stok_OlusturmaEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.tbl_kategoriler.ToList();
            var degerler = db.tbl_kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        //siteye herhangi bir işlem yapmazsam sadece sayfayı döndür.
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        //siteye herhangi bir işlem yapacaksam eğer aktifleştir.
        [HttpPost]
        public ActionResult YeniKategori(tbl_kategoriler p1)
        {
            //validation(onaylama) kontrolü sağlama
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tbl_kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        //butona basana kadar ekleme işlemi yapma

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.tbl_kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(tbl_kategoriler p1)
        {
            var kategori = db.tbl_kategoriler.Find(p1.KATEGORIID);
            kategori.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}