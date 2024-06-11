using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project_JobSearch.Models
{
    public class CompanyInsert
    {
        [Required(ErrorMessage = "Enter Company name")]
        public string name { set; get; }


        [Required(ErrorMessage = "Enter Company address")]
        public string address { set; get; }


        [EmailAddress(ErrorMessage ="Enter Valid Email id")]
        [Required(ErrorMessage = "Enter Email ")]
        public string email { set; get; }

        [Required(ErrorMessage = "Enter valid Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid number")]
        public long phone { set; get; }

        [Required(ErrorMessage = "Enter Username")]
        public string username { set; get; }

        [Required(ErrorMessage = "Enter Password")]
        public string pwd { set; get; }


        [Compare("pwd", ErrorMessage = "Password mismatch")]
        public string cpwd { set; get; }
        public string companymsg { set; get; }
    }
}