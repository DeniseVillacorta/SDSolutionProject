using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models.ContextModel
{
    public class Bus
    {
        public int Id { get; set; }
        public int BusNo { get; set; }
        public int PlateNo { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}