using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testingen.Data;
using testingen.Models;

namespace testingen.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{Id:int}")]
        public Customer GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        //post /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            //if (!ModelState.IsValid)
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //Put /api/customer/
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            //if (ModelState.IsValid)
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}

