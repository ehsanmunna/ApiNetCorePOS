using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using corepos.Services;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPOSRepository _posrepo;
        public PersonController(IPOSRepository posrepo) {
            _posrepo = posrepo;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            //return await _context.Person.ToListAsync();
            
            var persons = _posrepo.GetPersons();
            return new JsonResult(persons);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var person = _posrepo.GetPersonById(id);
            return new JsonResult(person);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
