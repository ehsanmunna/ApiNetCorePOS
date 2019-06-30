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
    public class ProductController : ControllerBase
    {
        private IPOSRepository _posrepo;
        public ProductController(IPOSRepository posrepo)
        {
            _posrepo = posrepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _posrepo.GetProduct();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var product = _posrepo.GetProductById(id);
            return new JsonResult(product);
        }

        [HttpPost]
        public ActionResult Save([FromBody] Product data)
        {
            var product = _posrepo.SaveProduct(data);
            return new JsonResult(product);
        }
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Product data)
        {
            var product = _posrepo.UpdateProduct(id, data);
            return new JsonResult(product);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var product = _posrepo.DeleteProduct(id);
            return new JsonResult(product);
        }
    }
}