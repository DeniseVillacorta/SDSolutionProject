﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestProject.Models.ContextModel
{
    public class Employee
    {
        public int Id { get; set; }

        [Display (Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Employee Number")]
        [Range(0, 999999999999999)]
        [Index("EmployeeNumber", IsUnique = true)]
        public int EmployeeNo { get; set; }

        [Display(Name = "Contact Number")]
        public long ContactNo { get; set; }
        public bool IsAssigned { get; set; }
    }
}