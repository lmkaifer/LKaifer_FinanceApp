using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LKaifer_FinanceApp.Models;
using Microsoft.AspNet.Identity;

namespace LKaifer_FinanceApp.Controllers
{

    [Authorize]
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Households
        [AuthorizeHouseholdRequired]
        public ActionResult Index()
        {
            var households = db.Households.Include(h => h.Owner);
            return View(households.ToList());
        }

        public ActionResult Setup(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Setup(WizardViewModel model)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                //Add and save Bank Account
                model.BankAccount.Created = DateTime.Now;
                model.BankAccount.OwnerId = User.Identity.GetUserId();
                db.BankAccounts.Add(model.BankAccount);
                db.SaveChanges();

                //Add and save Budget
                model.Budget.Created = DateTime.Now;
                model.Budget.HouseholdId = (int)user.HouseholdId;
                db.SaveChanges();


                //Add and save BudgetItem
                model.BudgetItem.Created = DateTime.Now;
                model.BudgetItem.BudgetId = model.Budget.Id;
                db.SaveChanges();
                //return RedirectToAction("Dashboard", "Households", new {ho);  
                return RedirectToAction("Details", "Households", new { id = user.HouseholdId });
            }
            return View(model);

        }
        //Redirect back to Dashboard
        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: Households/Create

        [Authorize]
        public ActionResult Create()
        {


            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Greeting,Established")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Households.Add(household);
                db.SaveChanges();

                //UserHelper.AddUserToHousehold(household.Id);

                return RedirectToAction("Dashboard");
            }

            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", household.OwnerId);
            return View(household);
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            //ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", household.OwnerId);
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerId,Name,Greeting,Established")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", household.OwnerId);
            return View(household);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
