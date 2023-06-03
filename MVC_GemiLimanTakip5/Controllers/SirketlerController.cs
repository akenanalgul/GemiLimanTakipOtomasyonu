using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_GemiLimanTakip5.Models.Entity;
namespace MVC_GemiLimanTakip5.Controllers
{
    public class SirketlerController : Controller
    {
        // GET: Sirketler
        MVC_LimanGemiTakipEntities1 db = new MVC_LimanGemiTakipEntities1();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Sirketler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Sirket.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.Sirketler.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSirket()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSirket(Sirketler p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniSirket");
            }

            db.Sirketler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var sirket = db.Sirketler.Find(id);
            db.Sirketler.Remove(sirket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SirketGetir(int id)
        {
            var srkt = db.Sirketler.Find(id);
            return View("SirketGetir", srkt);
        }
        public ActionResult Guncelle(Sirketler p)
        {
            var lm = db.Sirketler.Find(p.ID);
            lm.Sirket = p.Sirket;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}