﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKaifer_FinanceApp.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Greeting { get; set; }

        public DateTime Established { get; set; }

        public virtual ApplicationUser Owner { get; set; }
        public ICollection<Budget>Budgets { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        public Household()
        {
            BankAccounts = new HashSet<BankAccount>();
            Budgets = new HashSet<Budget>();
            Invitations = new HashSet<Invitation>();
            Notifications = new HashSet<Notification>();

        }

    }
}