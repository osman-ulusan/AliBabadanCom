using BLL.Identity;
using DAL.Context;
using Entity.Identity;
using Entity.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Host.SystemWeb;
using BLL.Repository;
using Entity.Entity;

namespace AliBabadanCom.Controllers
{
    public class UserController : BaseController
    {
        AliBabaContext db = new AliBabaContext();
        Repository<Ilan> repoA = new Repository<Ilan>(new AliBabaContext());
        Repository<Images> repoR = new Repository<Images>(new AliBabaContext());
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string userName, string password, string email)
        {
            var usermanager = IdentityTools.NewUserManager();  //*
            //var kullanici = usermanager.FindByName(model.Username);
            var kullanici = usermanager.FindByEmail(email);
            if (kullanici != null)
            {
                return Json("Bu emaili kullanamazsınız");
            }
            ApplicationUser user = new ApplicationUser();
            user.UserName = userName;
            user.Email = email;
            user.PasswordHash = password;

            var result = usermanager.Create(user, password);

            if (result.Succeeded)
            {
                usermanager.AddToRole(user.Id, "User");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    //ModelState.AddModelError(string.Empty, error);
                    return Json("Lütfen türkçe karakter kullanmayın ve alanların tamamını doldurunuz");
                }
            }
            return Json("Kayıt Tamamlandı");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string password, bool rememberme)
        {
            var usermanager = IdentityTools.NewUserManager();

            ApplicationUser kullanici = usermanager.FindByEmail(Email);
            if (kullanici == null)
            {
                return Json("Kullanıcı Adınızı Kontrol Ediniz");
            }
            else if (!usermanager.CheckPassword(kullanici, password))
            {
                return Json("Parolanızı Kontrol Ediniz");
            }
            else
            {
                var role = usermanager.GetRoles(kullanici.Id);
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identity = usermanager.CreateIdentity(kullanici, "ApplicationCookie");
                var authProperty = new AuthenticationProperties
                {
                    IsPersistent = rememberme
                };
                try
                {
                    authManager.SignIn(authProperty, identity);
                }
                catch (Exception)
                {

                    throw;
                }

                //string Id = HttpContext.User.Identity.GetUserId();
                //ApplicationUser User = new ApplicationUser();
                //User = (from u in ent.Users where u.Id == Id select u).FirstOrDefault();
                Session["User"] = Email;
                if (role[0] == "Admin")
                {
                    return Json("Admin");
                }
                else if (role[0] == "User")
                {
                    return Json("User");
                }
            }
            return Json("Böyle bir kullanıcı mevcut değil");
        }

        [Authorize(Roles = "User")]
        public ActionResult UserIndex()
        {
            string Id = HttpContext.User.Identity.GetUserId();
            List<Ilan> a = db.Ilan.Where(x => x.UserId == Id).ToList();
            return View(a);
        }

        [Authorize(Roles = "User")]
        public ActionResult IlanEkle()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlanEkle(IlanEkleViewModel model)
        {

            // Repository<Advert> repoA = new Repository<Advert>(new SatiyorumContext());            
            if (model.PictureUpload[1] != null)
            {
                string Id = HttpContext.User.Identity.GetUserId();
                var user = (from u in db.Users where u.Id == Id select u).FirstOrDefault();
                int i = 0;
                foreach (var resim in model.PictureUpload)
                {
                    string filename = model.PictureUpload[i].FileName;
                    string imagePath = Server.MapPath("/Content/images/" + filename);
                    model.PictureUpload[i].SaveAs(imagePath);
                    i++;
                }

                Images rsm = new Images();
                rsm.Image1 = model.PictureUpload[0].FileName;
                rsm.Image2 = model.PictureUpload[1].FileName;
                rsm.Image3 = model.PictureUpload[2].FileName;

                if (repoR.Add(rsm))
                {
                    db.SaveChanges();
                }

                Ilan yeni = new Ilan();
                yeni.Title = model.Title;
                yeni.Description = model.Description;
                yeni.ColorId = model.ColorId;
                yeni.Garanti = model.Garanti;
                yeni.KategoriId = model.KategoriId;
                yeni.AltKategoriId = model.AltKategoriId;
                yeni.MarkaId = model.MarkaId;
                yeni.ModelId = model.ModelId;
                yeni.CreateDate = DateTime.Now;
                yeni.UserId = Id;
                List<int> img = (from a in db.Images select a.Id).ToList();
                int sayi = img.Max();
                yeni.ImagesId = sayi;

                if (repoA.Add(yeni))
                {
                    db.SaveChanges();
                    return RedirectToAction("/UserIndex");
                }
                return View(model);
            }
            return View();
        }


        [HttpGet]
        public ActionResult IlanGuncelle(int id)
        {
            string Id = HttpContext.User.Identity.GetUserId();
            string user = (from u in db.Ilan where u.Id == id select u.UserId).FirstOrDefault();

            if (Id == user)
            {
                var a = db.Ilan.Where(x => x.Id == id).FirstOrDefault();

                IlanEkleViewModel ilanmodel = new IlanEkleViewModel();

                // int id1 = db.Color.Where(x => x.Name == a.Color).Select(x=>x.Id).FirstOrDefault();

                ilanmodel.AltKategoriId = a.AltKategoriId;
                ilanmodel.ColorId = a.ColorId;
                ilanmodel.Description = a.Description;
                ilanmodel.Garanti = a.Garanti;
                ilanmodel.Image1 = a.Images.Image1;
                ilanmodel.Image2 = a.Images.Image2;
                ilanmodel.Image3 = a.Images.Image3;
                ilanmodel.MarkaId = a.MarkaId;
                ilanmodel.ModelId = a.ModelId;
                ilanmodel.Title = a.Title;
                ilanmodel.KategoriId = a.KategoriId;

                return View(ilanmodel);
            }
            else
            {
                return View("/User/UserIndex");
            }
        }


        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlanGuncelle(int id, IlanEkleViewModel model)
        {
            if (model.PictureUpload[0] != null || model.PictureUpload[1] != null || model.PictureUpload[2] != null)
            {
                Images a = db.Ilan.Where(x => x.Id == id).Select(x => x.Images).FirstOrDefault();

                    if (model.PictureUpload[0] != null)
                    {
                        if (a.Image1 != model.PictureUpload[0].FileName)
                        {
                            a.Image1 = model.PictureUpload[0].FileName;
                            string filename = model.PictureUpload[0].FileName;
                            string imagePath = Server.MapPath("/Content/images/" + filename);
                            model.PictureUpload[0].SaveAs(imagePath);
                        }
                    }

                    if (model.PictureUpload[1] != null)
                    {
                        if (a.Image2 != model.PictureUpload[1].FileName)
                        {
                            a.Image2 = model.PictureUpload[1].FileName;
                            string filename = model.PictureUpload[1].FileName;
                            string imagePath = Server.MapPath("/Content/images/" + filename);
                            model.PictureUpload[1].SaveAs(imagePath);
                        }
                    }
                    if (model.PictureUpload[2] != null)
                    {
                        if (a.Image3 != model.PictureUpload[2].FileName)
                        {
                            a.Image3 = model.PictureUpload[2].FileName;
                            string filename = model.PictureUpload[2].FileName;
                            string imagePath = Server.MapPath("/Content/images/" + filename);
                            model.PictureUpload[2].SaveAs(imagePath);
                        }
                    }
                    db.SaveChanges();
            }

            try
            {
                Ilan guncelle = db.Ilan.Where(x => x.Id == id).FirstOrDefault();
                guncelle.Title = model.Title;
                guncelle.Description = model.Description;
                guncelle.ColorId = model.ColorId;
                guncelle.Garanti = model.Garanti;
                if (model.KategoriId != 0)
                {
                    guncelle.KategoriId = model.KategoriId;
                }
                if (model.AltKategoriId != 0)
                {
                    guncelle.AltKategoriId = model.AltKategoriId;
                }
                if (model.MarkaId != 0)
                {
                    guncelle.MarkaId = model.MarkaId;
                }
                if (model.ModelId != 0)
                {
                    guncelle.ModelId = model.ModelId;
                }
                db.SaveChanges();
                return RedirectToAction("/UserIndex");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult loadMarka(int altkategoriID)
        {
            return Json(db.Marka.Where(x => x.AltKategoriId == altkategoriID).Select(x => new
            {
                id = x.Id,
                Name = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadModel(int markaID)
        {
            return Json(db.Model.Where(x => x.MarkaId == markaID).Select(x => new
            {
                id = x.Id,
                Name = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadAltKategori(int kategoriID)
        {
            return Json(db.AltKategori.Where(x => x.KategoriId == kategoriID).Select(x => new
            {
                id = x.Id,
                Name = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}