using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_GemiLimanTakip5.Models.Entity;
using MVC_GemiLimanTakip5.Models;

namespace MVC_GemiLimanTakip5.Controllers
{
    public class GuvenlikController : Controller
    {
        MVC_LimanGemiTakipEntities1 db = new MVC_LimanGemiTakipEntities1();
        // GET: Guvenlik
        public ActionResult GirisYap()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisYap(Admin objuser)
        {
            if (ModelState.IsValid)
            {
                using(MVC_LimanGemiTakipEntities1 db=new MVC_LimanGemiTakipEntities1())
                {
                    var obj = db.Admin.Where(a => a.Kullanici.Equals(objuser.Kullanici) && a.Sifre.Equals(objuser.Sifre)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID.ToString();
                        Session["UserName"] = obj.Kullanici.ToString();
                        return RedirectToAction("Index","Anasayfa");
                    }
                    
                   
                }
            }
            return View(objuser);
        }
        public ActionResult UserDashBoard()
        {
            if (Session["ID"] != null)
            {
                return View();
                
            }
            else
            {
                return RedirectToAction("GirisYap");
            }
        
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("GirisYap","Guvenlik");
        }
    }
}