using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKaifer_FinanceApp.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public int AccountTypeId { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double StartingBalance { get; set; }
        public double CurrentBalance { get; set; }
        public double LowBalanceLevel { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public DateTime Created { get; set; }

        public virtual Household Household { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public BankAccount()
        {
            Transactions = new HashSet<Transaction>();

        }


    }
}