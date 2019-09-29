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
    public class StockController : ControllerBase
    {
        private IPOSRepository _posrepo;
        public StockController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var persons = _posrepo.GetStock();
            return new JsonResult(persons);
        }

        [HttpPost]
        public ActionResult Save([FromBody] Stock data)
        {
            var Stock = _posrepo.SaveStock(data);
            return new JsonResult(Stock);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Stock data)
        {
            var Stock = _posrepo.UpdateStock(id, data);
            return new JsonResult(Stock);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var Stock = _posrepo.DeleteStock(id);
            return new JsonResult(Stock);
        }

    }
}