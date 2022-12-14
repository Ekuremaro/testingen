using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testingen.Data;
using testingen.Models;
using testingen.ViewModel;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testingen.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //    //base.Dispose(disposing);
        //}

        // GET
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel { Customer = customer, MembershipTypes = _context.MembershipType.ToList() };
                return View("New", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult New()
        {

            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new NewCustomerViewModel { MembershipTypes = membershipTypes, Customer = new Customer() };
            return View(viewModel);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

    }
}

