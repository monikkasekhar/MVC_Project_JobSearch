using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project_JobSearch.Models
{
    public class JobInsert
    {
      [Required(ErrorMessage = "Enter Vacancy Name")]
        public string Job { set; get; }

        [Required(ErrorMessage = "Enter The Number of vacancy")]
        public int vacancy { set; get; }

        [Required(ErrorMessage = "Enter The Skill Required")]
        public string skill { set; get; }

        [Required(ErrorMessage = "Enter The Experience")]
        public string experience { set; get; }

        [Required(ErrorMessage = "Enter The Required Qualifiation")]
        public string qualification { set; get; }

        [Required(ErrorMessage = "Enter Salary")]
        public int Salary { set; get; }

        [Required(ErrorMessage = "Enter Job Location")]
        public string Location { set; get; }

        [Required(ErrorMessage = "Enter Entry Date")]
        public  DateTime startdate { set; get; }

        [Required(ErrorMessage = "Enter last Date")]
        public DateTime enddate { set; get; }

        public string msg { set; get; }


    }
}