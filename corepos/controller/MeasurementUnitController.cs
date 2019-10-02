using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using corepos.Entities;
using corepos.Models;
using corepos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementUnitController : Controller
    {
        private IPOSRepository _posrepo;
        public MeasurementUnitController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }
        // GET: MeasurementUnit
        [HttpGet]
        public IActionResult Get()
        {
            var units = _posrepo.GetUnits();
            var unitView = Mapper.Map<IEnumerable<MesurementUnitViewDto>>(units);
            return Ok(unitView);
        }

        // GET: MeasurementUnit/Details/5
        [HttpGet("{id}", Name = "GetMeasurementUnitId")]
        public ActionResult Get(int id)
        {
            var unit = _posrepo.GetUnitId(id);
            var unitView = Mapper.Map<MesurementUnitViewDto>(unit);
            return Ok(unitView);
        }


        // POST: MeasurementUnit/Create
        [HttpPost]
        public IActionResult Save([FromBody] MesurementUnitCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            //var groupEntity = req;
            var unitEntity = Mapper.Map<MeasurementUnit>(req);
            _posrepo.SaveUnit(unitEntity);
            return CreatedAtRoute("GetMeasurementUnitId", new { id = unitEntity.Id }, unitEntity);
        }

        // GET: MeasurementUnit/Edit/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MesurementUnitCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var unitById = _posrepo.GetUnitId(id);
            Mapper.Map(req, unitById);
            _posrepo.UpdateUnit(unitById);
            return StatusCode(204);
        }

        

        // GET: MeasurementUnit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}