using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_GemiLimanTakip5.Models.Entity;

namespace MVC_GemiLimanTakip5.Controllers
{
    public class GemilerController : Controller
    {
        // GET: Gemiler
        MVC_LimanGemiTakipEntities1 db = new MVC_LimanGemiTakipEntities1();
        public ActionResult Index()
        {
            
            var degerler = db.Gemiler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniGemi()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniGemi(Gemiler p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniGemi");
            }
        

            db.Gemiler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var gemi = db.Gemiler.Find(id);
            db.Gemiler.Remove(gemi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GemiGetir(int id)
        {
            var gm = db.Gemiler.Find(id);

            List<SelectListItem> degerler = (from i in db.Gemiler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SirketAdi,
                                                 Value = i.SirketID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;


            return View("GemiGetir", gm);
        }
        public ActionResult Guncelle(Gemiler p)
        {
            var gm = db.Gemiler.Find(p.ID);
            gm.SirketID = p.SirketID;
            gm.LimanID = p.LimanID;
            gm.Yuk = p.Yuk;
            gm.YukTonu = p.YukTonu;
            gm.Tonaj = p.Tonaj;
            gm.Murettebat = p.Murettebat;
            gm.Bayrak = p.Bayrak;
            gm.CikisTarihi = p.CikisTarihi;
            gm.VarisTarihi = p.VarisTarihi;
            gm.BulunduguLiman = p.BulunduguLiman;
            gm.VaracagiLiman = p.VaracagiLiman;
            gm.SirketAdi = p.SirketAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}