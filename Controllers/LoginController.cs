using CurrencyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrencyAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorize(CurrencyAPI.Models.User userModel)
        {
            using (LogInDataBaseEntities db = new LogInDataBaseEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Passwrod == x.Passwrod).FirstOrDefault();
                if (userDetails==null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";
                    return View("Index", userModel);
                }
                else
                {
                    Session["UserName"] = userDetails.UserName;
                    Session["UserID"] = userDetails.UserID;
                    return RedirectToAction("Search", "Home");
                }
            }
            
        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        
    }
}