using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project_JobSearch.Models;

namespace MVC_Project_JobSearch.Controllers
{
    public class CompanyRegController : Controller
    {
        MVC_JobSearch_DBEntities dbobj = new MVC_JobSearch_DBEntities();
        // GET: CompanyReg
        public ActionResult Company_Load()
        {
            return View();
        }

        public ActionResult Company_Click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;

                }
                else
                {
                    regid = mid + 1;
                }
                //get
                dbobj.sp_companyReg(regid, clsobj.name, clsobj.address, clsobj.email, clsobj.phone, "Available");
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pwd, "Company");
                clsobj.companymsg = "Registered Successfully";
                return View("Company_Load", clsobj);
            }
            return View("Company_Load", clsobj);
        }
    }
}