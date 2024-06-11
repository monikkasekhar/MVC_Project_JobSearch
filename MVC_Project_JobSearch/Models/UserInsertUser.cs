using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project_JobSearch.Models
{
    public class stclass
    {
        public int sId { set; get; }
        public string sName { set; get; }
    }
    public class CheckBoxListHelper
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }
    }
    public class UserInsertUser
    {
        
        public int sId { set; get; }
        public string sName { set; get; }

        public List<CheckBoxListHelper> MyFavoriteQual { set; get; }
        public string[] selectedQual { set; get; }

        [Required(ErrorMessage = "Enter Name")]
        public string name { set; get; }

        [Required(ErrorMessage = "Enter The Address")]
        public string address { set; get; }

        [Range(18, 50, ErrorMessage = "Enter Age")]
        public int age { set; get; }
        public string gen { set; get; }

        [Required(ErrorMessage = "Enter valid Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid number")]
        public long Phone { get; set; }

        [Required(ErrorMessage = "Enter Email ")]
        public string email { set; get; }

        [Required(ErrorMessage = "Enter District")]
        public string district { set; get; }

        [Required(ErrorMessage = "Enter Pincode")]
        public int pin { set; get; }

        public string qual { set; get; }

        [Required(ErrorMessage = "Enter cgpa")]
        public int cgpa { set; get; }
        public string skills { set; get; }
        public string status { set; get; }

        public string uname { set; get; }
        public string pwd { set; get; }

        [Compare("pwd", ErrorMessage = "Password mismatch")]
        public string cpwd { set; get; }
        public string usermsg { set; get; }
    }
}