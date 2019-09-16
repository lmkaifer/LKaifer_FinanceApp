using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKaifer_FinanceApp.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public double Target { get; set; }
        public double Actual { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual Household Household { get; set; }
        public virtual ICollection<BudgetItem> BudgetItems { get; set; }
        
        public Budget()
        {
            BudgetItems = new HashSet<BudgetItem>();
                    }
    }
}