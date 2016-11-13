using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.Controllers
{
    public class FirstController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: First
        public ActionResult Login()
        {
            Session["username"] = "";
            Session["Role"] = "";
            return View();
        }

        public string ConfirmLogin(int id, string password)
        {


            var user = db.Users.SingleOrDefault(c => c.Id == id);
            if (user == null)
                return "0";
            if (user.Password != password)
                return "1";

            Session["username"] = user.UserName;
            Session["Role"] = user.Role;

            if (Session["Role"].ToString() == "Admin")
            {
                return "2";
            }

            return "3";
        }

        public ActionResult Employee()
        {
            return View();
        }

    }
}