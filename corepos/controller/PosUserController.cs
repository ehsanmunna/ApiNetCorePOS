using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using corepos.Models;
using corepos.Helper;
using corepos.Services;
using AutoMapper;

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosUserController : Controller
    {
        private IPOSRepository _posrepo;
        public PosUserController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = _posrepo.GetPosUser();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Save([FromBody] PosUserFormDto req)
        {
            _posrepo.SavePosUser(req);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] PosUserFormDto req)
        {
            _posrepo.UpdatePosUser(id, req);
            return NoContent();
        }
    }
}