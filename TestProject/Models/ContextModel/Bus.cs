using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models.ContextModel
{
    public class Bus
    {
        public int Id { get; set; }

        [Display(Name = "Bus Number")]
        public int BusNo { get; set; }

        [Display(Name = "Plate Number")]
        public string PlateNo { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Employee Driver")]
        public int EmployeeId { get; set; }
    }
}