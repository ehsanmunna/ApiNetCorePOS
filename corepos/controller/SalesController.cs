using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using corepos.Services;
using corepos.Models.Sales;
using Microsoft.AspNetCore.Mvc;
using corepos.Entities;

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        private IPOSRepository _posrepo;
        public SalesController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var groups = _posrepo.GetSales();
            var groupView = Mapper.Map<IEnumerable<SalesViewDto>>(groups);
            return Ok(groupView);
        }
        // GET: api/<controller>/{id}
        [HttpGet("{id}", Name = "GetSalseMainById")]
        public IActionResult Get(string id)
        {
            var salsebyid = _posrepo.GetSalesById(id);
            var salseView = Mapper.Map<SalesViewDto>(salsebyid);
            return Ok(salseView);
        }

        [HttpPost]
        public ActionResult Save([FromBody] SalesMain req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var saveEntity = Mapper.Map<SalesMain>(req);
            _posrepo.SaveSales(saveEntity);
            return CreatedAtRoute("GetSalseMainById", new { id = saveEntity.SalesId }, saveEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Customer req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var salsebyid = _posrepo.GetSalesById(id);
            Mapper.Map(req, salsebyid);
            _posrepo.UpdateSales(salsebyid);

            return StatusCode(204);
        }
    }
}