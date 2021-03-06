﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject.Models;
using TestProject.Models.ContextModel;

namespace TestProject.Controllers.API
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /API/Employees    

        public IHttpActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();

            return Ok(employees);
        }

        //GET /API/Employees/1
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(s => s.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        //POST /API/Employees/CreateEmployee
        [HttpPost]
        public IHttpActionResult CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

          
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + employee.Id), employee);
        }

        //PUT /API/Employee/1
        [HttpPut]
        public void UpdateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var employeeToUpdate = _context.Employees.SingleOrDefault(i => i.Id == employee.Id);

            if (employeeToUpdate == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.SaveChanges();
        }

        //DELETE /API/Employees/1
        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var employee = _context.Employees.SingleOrDefault(i => i.Id == id);

            if (employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
