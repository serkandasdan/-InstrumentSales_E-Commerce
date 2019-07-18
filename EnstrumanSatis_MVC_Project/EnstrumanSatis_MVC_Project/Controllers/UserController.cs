

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using EnstrumanSatis_MVC_Project.Models;

namespace EnstrumanSatis_MVC_Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        EnstrumanSatisEntities db = new EnstrumanSatisEntities();
        public ActionResult Registration()
        {
          
            ViewBag.CityList = new SelectList(GetCityList(), "CityID", "City1");
            return View();
        }

        public ActionResult MyAccount()
        {
            User_ user = db.User_.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            return View(user);
        }

        public List<City> GetCityList()
        {
            EnstrumanSatisEntities db = new EnstrumanSatisEntities();
            List<City> cities = db.Cities.ToList();
            return cities;
        }
     
        public ActionResult GetTownList(int cityID)
        {
            EnstrumanSatisEntities db = new EnstrumanSatisEntities();
       
            List<Town> selectedList = db.Towns.Where(x => x.CityID == cityID).ToList();
            ViewBag.TList = new SelectList(selectedList, "TownID", "Town1");
            return PartialView("DisplayTown");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User_ user)
        {

            user.CreatedDate = DateTime.Now;

            bool Status = false;
            string message = "";
           
            if (ModelState.IsValid)
            {

                #region //Email is already Exist

                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "E-Posta Zaten Var");
                    return View(user);
                }

                var isExist2 = IsUserNameExist(user.UserName);
                if (isExist2)
                {
                    ModelState.AddModelError("UserNameExist", "Kullanıcı Adı Kullanılmış");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);

                user.IsEmailVerified = false;
                #endregion


                #region Save to Database
                using (EnstrumanSatisEntities db = new EnstrumanSatisEntities())
                {
                    db.User_.Add(user);
                 
                    db.SaveChanges();

                    SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());

                    message = " Hesap etkinleştirme bağlantısı " + user.Email + " e-posta adresinize gönderildi";
                    Status = true;
                }
                #endregion
            }

            else
            {
                message = "Geçersiz İstek";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(user);

        }

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (EnstrumanSatisEntities db = new EnstrumanSatisEntities())
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                var v = db.User_.Where(x => x.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    db.SaveChanges();
                    Status = true;

                }
                else
                {
                    ViewBag.Message = "Geçersiz İstek";

                }
            }
            ViewBag.Status = true;
            return View();
        }

        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl = "")
        {
            string message = "";
            using (EnstrumanSatisEntities db = new EnstrumanSatisEntities())
            {
                var v = db.User_.Where(x => x.UserName == login.UserName).FirstOrDefault();
        

                if (v != null)
                {

                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {

                        int timeout = login.RememberMe ? 525600 : 20;

                        var ticket = new FormsAuthenticationTicket(login.UserName, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return RedirectToAction(ReturnUrl);
                        }

                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Verilen bilgi geçersiz";
                    }
                }
                else
                {
                    message = "Verilen bilgi geçersiz";
                }


            }

            ViewBag.Message = message;
            return View();
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        //public ActionResult MyAccount()
        //{
        //    return View();
        //}

        [NonAction]
        public bool IsEmailExist(string Email)
        {
            using (EnstrumanSatisEntities db = new EnstrumanSatisEntities())
            {
                var v = db.User_.Where(x => x.Email == Email).FirstOrDefault();

                return v != null;
            }
        }
        [NonAction]
        public bool IsUserNameExist(string UserName)
        {
            using (EnstrumanSatisEntities db = new EnstrumanSatisEntities())
            {
                var v = db.User_.Where(x => x.UserName == UserName).FirstOrDefault();

                return v != null;
            }
        }



        [NonAction]
        public void SendVerificationLinkEmail(string Email,string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;

            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);


            var fromEmail = new MailAddress("***************************", "Wissen Proje");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "*********";
            string subject = "Hesabınız başarıyla oluşturuldu.";


            string body = "<br><br>Müzik Evreni hesabınızın başarıyla oluşturulduğunu " +
                "size bildirmekten mutluluk duyuyoruz.Hesabınızı doğrulamak için" +
                " lütfen aşağıdaki bağlantıyı tıklayın<br><br> <a href='" +link+ "'>" + link + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);


        }
    }
}
