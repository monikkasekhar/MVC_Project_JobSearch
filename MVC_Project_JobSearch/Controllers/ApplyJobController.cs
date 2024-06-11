using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project_JobSearch.Models;


namespace MVC_Project_JobSearch.Controllers
{
    public class ApplyJobController : Controller
    {
        MVC_JobSearch_DBEntities dbobj = new MVC_JobSearch_DBEntities();
        // GET: ApplyJob
        public ActionResult ApplyJob_Load(int cid, int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }
        public ActionResult ApplyJob_Click(ApplyJob clsobj, JobSearch obj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);


                    var fullpath = Path.Combine("~/Resume", fname);
                    clsobj.Resume = fullpath;

                }
                int uid = Convert.ToInt32(Session["uid"]);
                int cid = Convert.ToInt32(TempData["cid"]);
                int jid = Convert.ToInt32(TempData["jid"]);

                dbobj.sp_ApplyJob(jid, cid, uid, clsobj.Date, clsobj.Resume, "Available");
                //clsobj.applymsg = "successfully applied";
                return View("ApplyJob_Load");

            }
            return View("ApplyJob_Load");
        }
    }
}