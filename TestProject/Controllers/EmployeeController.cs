using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;
using TestProject.Models.ContextModel;
using TestProject.Models.ViewModel.Employees;

namespace TestProject.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new EmployeeFormViewModel
            {
                Employee = new Employee()
            };

            return View("EmployeeForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
            };

            return View("EmployeeForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
                return HttpNotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeForm");
            }

            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
                

            }
            else
            {
                var employeeInDB = _context.Employees.Single(e => e.Id == employee.Id);

                if (employeeInDB == null)
                    return HttpNotFound();

                employeeInDB.FirstName = employee.FirstName;
                employeeInDB.LastName = employee.LastName;
                employeeInDB.EmployeeNo = employee.EmployeeNo;
                employeeInDB.ContactNo = employee.ContactNo;
               
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}