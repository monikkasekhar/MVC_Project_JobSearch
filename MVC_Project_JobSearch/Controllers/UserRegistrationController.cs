using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project_JobSearch.Models;
using static MVC_Project_JobSearch.Models.UserInsertUser;

namespace MVC_Project_JobSearch.Controllers
{
    public class UserRegistrationController : Controller
    {
        MVC_JobSearch_DBEntities dbobj = new MVC_JobSearch_DBEntities();
        // GET: UserRegistration
        public ActionResult User_load()
        {
            //dropdownlist

            List<stclass> stList = new List<stclass>

            {
                new stclass{sId=1, sName="Kerala"},
                new stclass {sId = 2, sName = "Karnataka" },
                new stclass {sId = 3, sName = "Tamilnadu" }
        };

            ViewBag.Selstates = new SelectList(stList, "sId", "sName");

            //checkboxlist
            UserInsertUser user = new UserInsertUser();
            user.MyFavoriteQual = getQualificationData();
            return View(user);
        }

        //checkboxlist
        public List<CheckBoxListHelper> getQualificationData()
        {
            List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new CheckBoxListHelper{Value="Plus TWO",Text="PLUS TWO",IsChecked=false},
                new CheckBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
                new CheckBoxListHelper{Value="MCA",Text="MCA",IsChecked=false},
                new CheckBoxListHelper{Value="B-TECH",Text="B-TECH",IsChecked=false},
            };
            return sts;
        }

        public ActionResult User_Click(UserInsertUser clsobj, FormCollection form)
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
                //dropdownlist
                List<stclass> stList = new List<stclass> //object
                {
                    new stclass{sId=1, sName="Kerala"},
                    new stclass {sId = 2, sName = "Karnataka" },
                    new stclass {sId = 3, sName = "Tamilnadu" }

                };

                int selectedId = Convert.ToInt32(form["selstates"]);
                stclass selectedItem = stList.FirstOrDefault(c => c.sId == selectedId);
                clsobj.sId = selectedItem.sId;
                clsobj.sName = selectedItem.sName;

                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                //checkbox
                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.qual = quid;
                clsobj.MyFavoriteQual = getQualificationData();

                dbobj.sp_userReg(regid, clsobj.name, clsobj.address, clsobj.age, clsobj.gen, 
                    clsobj.Phone, clsobj.email, clsobj.sName, clsobj.district, clsobj.pin, clsobj.qual, 
                    clsobj.cgpa, clsobj.skills, "Available");
                dbobj.sp_logininsert(regid, clsobj.uname, clsobj.pwd, "User");
                clsobj.usermsg = "Successfully Registered";
                return View("User_load", clsobj);
            }
            else
            {
                List<stclass> stList = new List<stclass> //object
                {
                    new stclass{sId=1, sName="Kerala"},
                    new stclass {sId = 2, sName = "Karnataka" },
                    new stclass {sId = 3, sName = "Tamilnadu" }

                };

                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                //checkbox
                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.qual = quid;
                clsobj.MyFavoriteQual = getQualificationData();

                return View("User_load", clsobj);

            }
            return View("User_load", clsobj);

        }
    }
}