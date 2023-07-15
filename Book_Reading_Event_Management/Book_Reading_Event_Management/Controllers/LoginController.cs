using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Book_Reading_Event_Management.Models;

namespace Book_Reading_Event_Management.Controllers
{
    public class LoginController : Controller
    {
        BookReadingEventManagementEntities db = new BookReadingEventManagementEntities();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(User userEnteredCredentials, string RetrunUrl)
        {
            if(IsValid(userEnteredCredentials)==true)
            {
                FormsAuthentication.SetAuthCookie(userEnteredCredentials.Email, false);
                
                if (RetrunUrl!=null)
                {
                    return Redirect(RetrunUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "The Email or password is incorrect");
                return View();
            }
            
        }
        public bool IsValid(User userEnteredCredentials)
        {
            var credentials = db.Users.Where(model => model.Email == userEnteredCredentials.Email && model.Password == userEnteredCredentials.Password).FirstOrDefault();
            
            if (credentials != null)
            {
                Session["FullName"] = credentials.FullName.ToString();
                Session["Email"] = credentials.Email;
                Session["UserID"] = credentials.UserID;
                Session["IsAdmin"] = credentials.IsAdmin.ToString();
                return (userEnteredCredentials.Email == credentials.Email && userEnteredCredentials.Password == credentials.Password);
            }
            else
            {
                return false;
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["FullName"] = null;
            Session["Email"] = null;
            Session["UserID"]= null;
            Session["IsAdmin"]= null;


            return RedirectToAction("Index","Home");
        }
    }
}