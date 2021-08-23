using DapperDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment3.Controllers
{
    public class CustomerController : Controller
    {
        CustomerService customerService;
        public CustomerController(CustomerService _customerService)
        {
            customerService = _customerService;
        }
        public IActionResult Index()
        {
            List<Customer> Cus= customerService.getCustomers();
            return View(Cus);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                customerService.saveCustomer(customer);
            }
            catch (Exception e)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            //Customer customer = customerService.getCustomer(id);
            Customer customer = customerService.spgetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer c)
        {
            try
            {
                customerService.updateCustomer(c);
            }
            catch (Exception e)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                customerService.deleteCustomer(id);
            }
            catch (Exception e)
            {
            }

            return RedirectToAction("Index");
        }

    }
}
