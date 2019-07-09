using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corepos.Entities;
using corepos.Services;
using Microsoft.AspNetCore.Mvc;

namespace corepos.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IPOSRepository _posrepo;
        public ItemController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var persons = _posrepo.GetItem();
            return new JsonResult(persons);
        }

        [HttpPost]
        public ActionResult Save([FromBody] Item data)
        {
            var item = _posrepo.SaveItem(data);
            return new JsonResult(item);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Item data)
        {
            var item = _posrepo.UpdateItem(id, data);
            return new JsonResult(item);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var item = _posrepo.DeleteItem(id);
            return new JsonResult(item);
        }

    }
}