using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GemiLimanTakip5.Controllers
{
    public class CerezController : Controller
    {
        // GET: Cerez
        public ActionResult OnlineUyeSayisi()
        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];
            return View();
        }
        public ActionResult Olustur()
        {
            HttpCookie cookieKullanici = new HttpCookie("kullanici", "zeynep");
            HttpContext.Response.Cookies.Add(cookieKullanici);
            ViewBag.Kullanici = HttpContext.Request.Cookies["kullanici"].Value;
            return View();
        }
        public ActionResult Sil()
        {

            HttpContext.Request.Cookies.Remove("kullanici");

            
            return View();
        }

    }
}