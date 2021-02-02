using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int EmployeeNo { get; set; }

        [Display(Name = "Contact Number")]
        public int ContactNo { get; set; }
        public bool IsAssigned { get; set; }
    }
}