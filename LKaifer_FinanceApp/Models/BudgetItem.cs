using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKaifer_FinanceApp.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Target { get; set; }
        public double Actual { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set;}

        public virtual Budget Budget { get; set; }
       
        public ICollection<Transaction>Transactions { get; set; }
        public BudgetItem()
        {
            Transactions = new HashSet<Transaction>();
        }
            
    }
}