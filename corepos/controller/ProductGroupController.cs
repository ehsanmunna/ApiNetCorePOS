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
    public class ProductGroupController : Controller
    {
        private IPOSRepository _posrepo;
        public ProductGroupController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var groups = _posrepo.GetProductGroups();
            var groupView = Mapper.Map<IEnumerable<GroupViewDto>>(groups);
            return Ok(groupView);
        }


        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetProductGroupById")]
        public ActionResult Get(int id)
        {
            var groups = _posrepo.GetUnitId(id);
            var groupView = Mapper.Map<GroupViewDto>(groups);
            return Ok(groupView);
        }
        [HttpPost]
        public IActionResult Save([FromBody] GroupCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            //var groupEntity = req;
            var groupEntity = Mapper.Map<ProductGroup>(req);
            _posrepo.SaveProductGroup(groupEntity);
            return CreatedAtRoute("GetCustomerById", new { id = groupEntity.Id }, groupEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GroupCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var groupById = _posrepo.GetProductGroupById(id);
            Mapper.Map(req, groupById);
            _posrepo.UpdateProductGroup(groupById);
            return StatusCode(204);
        }
    }
}
