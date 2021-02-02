using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;
using TestProject.Models.ContextModel;
using TestProject.Models.ViewModel.Buses;

namespace TestProject.Controllers
{
    public class BusController : Controller
    {
        private ApplicationDbContext _context;

        public BusController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Bus
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            var employees = _context.Employees.ToList();

            var viewModel = new BusFormViewModel
            {
                Bus = new Bus(),
                Employees = employees
            };

            return View("BusForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var bus = _context.Buses.SingleOrDefault(e => e.Id == id);
            var employees = _context.Employees.ToList();

            if (bus == null)
                return HttpNotFound();

            var viewModel = new BusFormViewModel
            {
                Bus = bus,
                Employees = employees
            };

            return View("BusForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var bus = _context.Buses.SingleOrDefault(e => e.Id == id);

            if (bus == null)
                return HttpNotFound();

           

            _context.Buses.Remove(bus);
            var employee = _context.Employees.Where(b => b.Id == bus.EmployeeId && b.IsAssigned == true).FirstOrDefault();
            bus.Employee = employee;
            bus.Employee.IsAssigned = false;
            _context.SaveChanges();

            return RedirectToAction("Index", "Bus");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return View("BusForm");
            }


            if (bus.Id == 0)
            {
                var employee = _context.Employees.Where(b => b.Id == bus.EmployeeId).FirstOrDefault();
                bus.Employee = employee;
                bus.Employee.IsAssigned = true;
                _context.Buses.Add(bus);
            }
            else
            {
                var busInDB = _context.Buses.SingleOrDefault(b => b.Id == bus.Id);

                if (busInDB == null)
                return HttpNotFound();

                busInDB.BusNo = bus.BusNo;
                busInDB.PlateNo = bus.PlateNo;
                busInDB.EmployeeId = bus.EmployeeId;

                var employee = _context.Employees.Where(b => b.Id == busInDB.EmployeeId).FirstOrDefault();
                bus.Employee = employee;
                bus.Employee.IsAssigned = true;

            }

           

            _context.SaveChanges();
            return RedirectToAction("Index", "Bus");
        }
    }
}