using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project_JobSearch.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC_Project_JobSearch.Controllers
{
    public class Job_SearchController : Controller
    {
        MVC_JobSearch_DBEntities dbobj = new MVC_JobSearch_DBEntities();
        // GET: Job_Search
        public ActionResult Searchjob_Pageload()
        {
            return View(GetData());
        }

        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.AddJobs.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.job_id = e.JobId;
                jobcls.company_id = e.Co_Id;
                jobcls.jobname = e.JobName;
                jobcls.numofvacancy = e.Vacancy;
                jobcls.reqskills = e.RequiredSkill;
                jobcls.experience = e.Experience;
                jobcls.qualification = e.Qualification;
                jobcls.salary = e.Salary;
                jobcls.location = e.Location;
                jobcls.entrydate = e.StartDate;
                jobcls.lastdate = e.EndDate;
                jobcls.jobstatus = e.JobStatus;
                joblist.selectjob.Add(jobcls);
                var s = jobcls.reqskills;
                lst.Add(s);
                TempData["ski"] = string.Join("", lst);

            }
            return joblist;
        }

        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.jobname))
            {
                qry += "and JobName like '%" + clsobj.insertse.jobname + "%'";


            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.reqskills))
            {
                qry += "and RequiredSkill like '%" + clsobj.insertse.reqskills + "%'";

            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.location))
            {
                qry += "and Location like '%" + clsobj.insertse.location + "%'";

            }

            return View("Searchjob_Pageload", getdata1(clsobj, qry));


        }
        private JobSearch getdata1(JobSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_JobView_Check2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    var joblist = new JobSearch();
                    while (dr.Read())
                    {
                        var jobcls = new jsearch();
                        jobcls.job_id = Convert.ToInt32(dr["JobId"].ToString());
                        jobcls.company_id = Convert.ToInt32(dr["Co_Id"].ToString());
                        jobcls.jobname = dr["JobName"].ToString();
                        jobcls.numofvacancy = Convert.ToInt32(dr["Vacancy"].ToString());
                        jobcls.reqskills = dr["RequiredSkill"].ToString();
                        jobcls.experience = dr["Experience"].ToString();
                        jobcls.qualification = dr["Qualification"].ToString();
                        jobcls.salary = Convert.ToInt32(dr["Salary"].ToString());
                        jobcls.location = dr["Location"].ToString();
                       
                        jobcls.entrydate = Convert.ToDateTime(dr["StartDate"].ToString());
                        jobcls.lastdate = Convert.ToDateTime(dr["EndDate"].ToString());
                        jobcls.jobstatus = dr["JobStatus"].ToString();
                        joblist.selectjob.Add(jobcls);

                    }
                    con.Close();
                    return joblist;
                }
            }
        }

    }
}