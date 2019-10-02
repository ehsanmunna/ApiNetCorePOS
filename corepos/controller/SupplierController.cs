using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using corepos.Entities;
using corepos.Models;
using corepos.Services;
using Microsoft.AspNetCore.Mvc;

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private IPOSRepository _posrepo;
        public SupplierController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }
        // GET: Supplier
        [HttpGet]
        public IActionResult Get()
        {
            var list = _posrepo.GetSuppliers();
            var listView = Mapper.Map<IEnumerable<SupplierViewDto>>(list);
            return Ok(listView);
        }

        // GET: Supplier/5
        [HttpGet("{id}", Name = "GetSupplierId")]
        public ActionResult Get(string id)
        {
            var obj = _posrepo.GetSupplierId(id);
            var objView = Mapper.Map<SupplierViewDto>(obj);
            return Ok(objView);
        }


        // POST: Supplier
        [HttpPost]
        public IActionResult Save([FromBody] SupplierCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            //var groupEntity = req;
            var createEntity = Mapper.Map<Supplier>(req);
            _posrepo.SaveSupplier(createEntity);
            return CreatedAtRoute("GetSupplierId", new { id = createEntity.Id }, createEntity);
        }

        // GET: Supplier/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] SupplierCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var objById = _posrepo.GetSupplierId(id);
            Mapper.Map(req, objById);
            _posrepo.UpdateSupplier(objById);
            return StatusCode(204);
        }



        // GET: Supplier/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}