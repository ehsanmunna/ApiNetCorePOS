using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using corepos.Entities;
using corepos.Models.Product;
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
            var listView = Mapper.Map<IEnumerable<ProductViewDto>>(products);
            return Ok(listView);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult Get(string id)
        {
            var products = _posrepo.GetProductById(id);
            var listView = Mapper.Map<ProductViewDto>(products);
            return Ok(listView);
        }

        [HttpPost]
        public ActionResult Save([FromBody] Product req)
        {
            if (req == null)
            {
                return BadRequest();
            }
            var productEntity = Mapper.Map<Product>(req);
            _posrepo.SaveProduct(productEntity);
            return CreatedAtRoute("GetProductById", new { id = productEntity.ProdId }, productEntity);
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