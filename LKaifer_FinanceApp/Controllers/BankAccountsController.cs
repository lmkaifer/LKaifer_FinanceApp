﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LKaifer_FinanceApp.Models;

namespace LKaifer_FinanceApp.Controllers
{
    public class BankAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BankAccounts
        public ActionResult Index()
        {
            var bankAccounts = db.BankAccounts.Include(b => b.AccountType).Include(b => b.Household).Include(b => b.Owner);
            return View(bankAccounts.ToList());
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Type");
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "OwnerId");
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HouseholdId,AccountTypeId,OwnerId,Name,Description,StartingBalance,CurrentBalance,LowBalanceLevel,Address1,Address2,City,State,Zip,Phone,Created")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(bankAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Type", bankAccount.AccountTypeId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "OwnerId", bankAccount.HouseholdId);
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", bankAccount.OwnerId);
            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Type", bankAccount.AccountTypeId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "OwnerId", bankAccount.HouseholdId);
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", bankAccount.OwnerId);
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HouseholdId,AccountTypeId,OwnerId,Name,Description,StartingBalance,CurrentBalance,LowBalanceLevel,Address1,Address2,City,State,Zip,Phone,Created")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Type", bankAccount.AccountTypeId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "OwnerId", bankAccount.HouseholdId);
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", bankAccount.OwnerId);
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankAccount bankAccount = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(bankAccount);
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
