﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKaifer_FinanceApp.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string OwnerId { get; set; }
        public DateTime Created { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public virtual Household Household { get; set; }
        public virtual ApplicationUser Owner {get; set;}

       
    }
}