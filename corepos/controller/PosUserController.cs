using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using corepos.Models;
using corepos.Helper;
using corepos.Services;
using AutoMapper;
using corepos.Entities;

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

        [HttpGet("{id}", Name = "GetPosUserById")]
        public IActionResult GetById(string id)
        {
            var user = _posrepo.GetPosUserById(id);
            var userView = Mapper.Map<PosUserViewDto>(user);
            return Ok(userView);
        }

        [HttpPost]
        public IActionResult Save([FromBody] ProductGroupCreateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var userEntity = Mapper.Map<PosUser>(req);
            _posrepo.SavePosUser(userEntity);
            return CreatedAtRoute("GetPosUserById", new { id = userEntity.UserId }, userEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] PosUserUpdateDto req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var userbyId = _posrepo.GetPosUserById(id);
            Mapper.Map(req, userbyId);
            _posrepo.UpdatePosUser(userbyId);

            return StatusCode(204);
        }
    }
}