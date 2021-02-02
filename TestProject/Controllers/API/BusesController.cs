using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject.Models;
using TestProject.Models.ContextModel;

namespace TestProject.Controllers.API
{
    public class BusesController : ApiController
    {
        private ApplicationDbContext _context;

        public BusesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /API/Buses  

        public IHttpActionResult GetBuses()
        {
            var buses = _context.Buses.Include("Employee")
                                      .ToList();

            return Ok(buses);
        }

        //GET /API/Buses/1
        public IHttpActionResult GetBus(int id)
        {
            var bus = _context.Buses.Include("Employee")
                                    .SingleOrDefault(s => s.Id == id);

            if (bus == null)
                return NotFound();

            return Ok(bus);
        }

        //POST /API/Buses/CreateBus
        [HttpPost]
        public IHttpActionResult CreateBus(Bus bus)
        {
            if (!ModelState.IsValid)
                return BadRequest();

          
            _context.Buses.Add(bus);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + bus.Id), bus);
        }

        //PUT /API/Buses/1
        [HttpPut]
        public void UpdateBus(Bus bus)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var busToUpdate = _context.Buses.SingleOrDefault(i => i.Id == bus.Id);

            if (busToUpdate == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            bus.Employee.IsAssigned = false;

            _context.SaveChanges();
        }

        //DELETE /API/Buses/1
        [HttpDelete]
        public void DeleteBus(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bus = _context.Buses.SingleOrDefault(i => i.Id == id);

            if (bus == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            var employee = _context.Employees.Where(b => b.Id == bus.EmployeeId && b.IsAssigned == true).FirstOrDefault();
            bus.Employee = employee;
            bus.Employee.IsAssigned = false;

            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }
    }
}
