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
        private IAuthRepository _posrepo;
        public PosUserController(IAuthRepository posrepo)
        {
            _posrepo = posrepo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = _posrepo.GetPosUser();
            var userView = Mapper.Map<IEnumerable<PosUserViewDto>>(user);
            return Ok(userView);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = _posrepo.GetPosUserById(id);
            var userView = Mapper.Map<PosUserViewDto>(user);
            return Ok(userView);
        }

        [HttpPost]
        public IActionResult Save([FromBody] PosUserFormDto req)
        {
            _posrepo.SavePosUser(req);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] PosUserViewDto req)
        {
            var data = _posrepo.UpdatePosUser(id, req);
            
            return Ok(data);
        }
    }
}