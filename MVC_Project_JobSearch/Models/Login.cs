using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project_JobSearch.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter The Username")]
        public string username { set; get; }

        [Required(ErrorMessage = "Enter password")]
        public string password { set; get; }
        public string msg { set; get; }
        public string ltype { set; get; }
    }
}