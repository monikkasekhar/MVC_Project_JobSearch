using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Project_JobSearch.Models
{
    public class ApplyJob
    {
        
        public int jobId { get; set; }
       
        public int CId  { get; set; }
        public int UId { get; set; }
        
        public DateTime applydate { get; set; }
        public string resume { get; set; }
        public string applystatus { get; set; }

        //public string applymsg { get; set; }

    }
}