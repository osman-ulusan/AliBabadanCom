using BLL.Identity;
using BLL.Repository;
using DAL.Context;
using Entity.Entity;
using Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliBabadanCom.Controllers
{
   
    public class HomeController : BaseController
    {
        AliBabaContext db = new AliBabaContext();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            AliBabaContext db = new AliBabaContext();

            return View(db.Ilan.ToList());
        }

        public ActionResult UrunDetay(int? id)
        {
            Ilan a = db.Ilan.Where(x => x.Id == id).FirstOrDefault();
            a.GörüntülenmeSayisi += 1;
            db.SaveChanges();
            return View(a);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}