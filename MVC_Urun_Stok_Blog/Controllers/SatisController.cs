using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Urun_Stok_Blog.Models.EntityFramework;

namespace MVC_Urun_Stok_Blog.Controllers
{
    public class SatisController : Controller
    {
        MVC_Urun_Stok_OlusturmaEntities db = new MVC_Urun_Stok_OlusturmaEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tbl_satislar p1)
        {
            db.tbl_satislar.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}