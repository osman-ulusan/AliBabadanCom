using BLL.Repository;
using DAL.Context;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliBabadanCom.Controllers
{
    public class BaseController : Controller
    {
        AliBabaContext ent = new AliBabaContext();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Repository<Kategori> repoK = new Repository<Kategori>(ent);
            ViewBag.Kategori = repoK.GetAll();

            Repository<Model> repoMo = new Repository<Model>(ent);
            ViewBag.Model = repoMo.GetAll();

            Repository<Marka> repoM = new Repository<Marka>(ent);
            ViewBag.Marka = repoM.GetAll();

            Repository<AltKategori> repoT = new Repository<AltKategori>(ent);
            ViewBag.AltKategori = repoT.GetAll();

            Repository<Color> repoC = new Repository<Color>(ent);
            ViewBag.Color = repoC.GetAll();

            base.OnActionExecuting(filterContext);
        }
    }
}