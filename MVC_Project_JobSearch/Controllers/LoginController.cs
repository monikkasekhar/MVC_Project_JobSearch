using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project_JobSearch.Models;



namespace MVC_Project_JobSearch.Controllers
{
    public class LoginController : Controller
    {
        MVC_JobSearch_DBEntities dbobj = new MVC_JobSearch_DBEntities();
        // GET: Login
        public ActionResult Login_pageLoad()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult Login_Click(Login clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_Login(clsobj.username, clsobj.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(clsobj.username, clsobj.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_loginType(clsobj.username, clsobj.password).FirstOrDefault();


                    if (lt == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "Company")
                    {
                        return RedirectToAction("AdminHome");
                    }

                }
                else
                {
                    ModelState.Clear();
                    clsobj.msg = "Invalid Login";
                    return View("Login_pageLoad", clsobj);
                }

            }
            return View("Login_pageLoad", clsobj);
        }
    }
}