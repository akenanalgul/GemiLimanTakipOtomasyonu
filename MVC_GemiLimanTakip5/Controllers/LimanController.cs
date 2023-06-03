using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_GemiLimanTakip5.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MVC_GemiLimanTakip5.Controllers
{
    public class LimanController : Controller
    {
        // GET: Liman
      MVC_LimanGemiTakipEntities1 db = new MVC_LimanGemiTakipEntities1();

        

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Limanlar.ToList();
            var degerler = db.Limanlar.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        public ActionResult KategoriDetay(int id)
        {
            var degerler = db.Sirketler.Where(x => x.ID == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniLiman()
        {
            
            return View();  
        }

        [HttpPost]
        public ActionResult YeniLiman(Limanlar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniLiman");
            }
            
            db.Limanlar.Add(p);
            db.SaveChanges();
            return View();
        }
         public ActionResult SIL(int id)
        {
            var liman = db.Limanlar.Find(id);
            db.Limanlar.Remove(liman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LimanGetir(int id)
        {
            var lm = db.Limanlar.Find(id);
            return View("LimanGetir", lm);
        }
        public ActionResult Guncelle(Limanlar p)
        {
            var lm = db.Limanlar.Find(p.ID);
            lm.Liman = p.Liman;
            lm.Sehir = p.Sehir;
            lm.Ulke = p.Ulke;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}