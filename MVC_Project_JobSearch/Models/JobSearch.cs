using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Project_JobSearch.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { get; set; }
        public List<jsearch> selectjob { get; set; }
    }
    public class jsearch
    {
        public int job_id { get; set; }
        public int company_id { get; set; }
        public string jobname { get; set; }
        public int numofvacancy { get; set; }
        public string reqskills { get; set; }
        public string experience { get; set; }
        public string qualification { get; set; }
        public int salary { get; set; }
        public string location { get; set; }
        public DateTime entrydate { get; set; }
        public DateTime lastdate { get; set; }
        public string jobstatus { get; set; }
        public string jobmsg { get; set; }


    }
}