﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LKaifer_FinanceApp.Models
{
    public class Invitation

    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string OwnerId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        [Display(Name = "Time to live")]
        public int TTL { get; set; }
        public bool IsValid { get; set; }
        public Guid Code { get; set; }
        public virtual Household Household { get; set; }
        public virtual ApplicationUser Owner { get; set; }


    }
}