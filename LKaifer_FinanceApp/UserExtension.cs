using LKaifer_FinanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

//namespace LKaifer_FinanceApp
//{
//    public static class UserExtension
//    {
//        private static ApplicationDbContext db = new ApplicationDbContext();

//        public static async Task ReauthorizeUserAsync(this ApplicationUser user)
//        {
//            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
//            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
//​
//            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
//            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
//            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
//        }
//    }
//}







