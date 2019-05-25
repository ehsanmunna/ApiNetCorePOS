using corepos.Entities;
using corepos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private IPOSRepository _posrepo;
        public CustomerController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            var customerList = new List<Customer>();
            var customers = _posrepo.GetCustomers();

            //foreach (var item in customers)
            //{
            //    customerList.Add(new Customer()
            //    {
            //        custId = item.CustId,
            //        person_id = item.PersonId,
            //        Person = _posrepo.GetPersonById(item.person_id)
            //    });
            //}

            return new JsonResult(customers);
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var customer = _posrepo.GetCustomerById(id);
            customer.Person = _posrepo.GetPersonById(customer.PersonId);
            return new JsonResult(customer);
        }
    }
}
