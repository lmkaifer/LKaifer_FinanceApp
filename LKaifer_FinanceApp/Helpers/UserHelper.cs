using LKaifer_FinanceApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace LKaifer_FinanceApp.Helpers
//{
//    public class UserHelper
//    {
//        private static ApplicationDbContext db { get; set; }
//        private static ApplicationUser CurrentUser { get; set; }
//        //private string UserId = HttpContext.Current.User.Identity.GetUserId();
//        private RoleManager<IdentityRole>roleManager { get; set; }

//    public UserHelper()
//    {
//            var userId = HttpContext.Current.User.Identity.GetUserId();
//            CurrentUser = db.Users.Find(userId);
//            RoleManager = new RoleManager<IdentityRole>(new RoleManager)
//        }
//    public void AddUserToHousehold(int houseId)
//    {
//            db.Users.Attach(CurrentUser);
//            CurrentUser.AssignHousehold(houseId);
//            db.SaveChanges();
            
//    }
//        public void AddUserToRole()
//        {
//            UserManager.AddToRole(CurrentUser.Id, role.ToString());

//        }
//        public void AssignUserToHeadofHousehold
//        {

//        }
//}
//    }
//}