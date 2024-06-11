using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project_JobSearch.Models;

namespace MVC_Project_JobSearch.Controllers
{
    public class JobAddController : Controller
    {
        MVC_JobSearch_DBEntities dbobj = new MVC_JobSearch_DBEntities();
        // GET: JobAdd
        public ActionResult JobAdd_Load()
        {
            return View();
        }

        public ActionResult JobAdd_Click(JobInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                int cid = Convert.ToInt32(Session["uid"]);//regid
                dbobj.sp_JobInsert(cid, clsobj.Job, clsobj.vacancy, clsobj.skill, clsobj.experience,
                    clsobj.qualification, clsobj.Salary, clsobj.Location, clsobj.startdate, clsobj.enddate, "Active");
                clsobj.msg = "Job Posted";
                return View("JobAdd_Load", clsobj);
            }
            return View("JobAdd_Load", clsobj);

        }

    }
}