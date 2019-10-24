using DAL.Context;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliBabadanCom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        AliBabaContext db = new AliBabaContext();
        // GET: Admin
        public ActionResult Index()
        {
            Ilan a = new Ilan();
            a = db.Ilan.Where(x => x.IsConfirmed == false).FirstOrDefault();
            return View(a);
        }

        [HttpGet]
        public ActionResult Onayla(int? Id)
        {
            Ilan a = new Ilan();
            //a = db.Ilan.Where(x => x.Id == Id).FirstOrDefault();
            //a.IsConfirmed = true;
            a = (from adv in db.Ilan where adv.Id == Id select adv).FirstOrDefault();
            try
            {
                a.IsConfirmed = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}

