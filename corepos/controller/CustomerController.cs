using AutoMapper;
using corepos.Entities;
using corepos.Models;
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
        public IActionResult Get()
        {
            var user = _posrepo.GetCustomers();
            var userView = Mapper.Map<IEnumerable<CustomerViewDto>>(user);
            return Ok(userView);
        }


        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult Get(string id)
        {
            var user = _posrepo.GetCustomerById(id);
            var userView = Mapper.Map<CustomerViewDto>(user);
            return Ok(userView);
        }
        [HttpPost]
        public IActionResult Save([FromBody] CustomerCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var userEntity = Mapper.Map<Customer>(req);
            _posrepo.SaveCustomer(userEntity);
            return CreatedAtRoute("GetCustomerById", new { id = userEntity.CustId }, userEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Customer req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var userbyId = _posrepo.GetCustomerById(id);
            Mapper.Map(req, userbyId);
            _posrepo.UpdateCustomer(userbyId);

            return StatusCode(204);
        }
    }
}
