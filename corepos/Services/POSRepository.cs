using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corepos.Entities;
using corepos.Models;
using Microsoft.AspNetCore.Mvc;
using corepos.Helper;
using Microsoft.EntityFrameworkCore;

namespace corepos.Services
{
    public class POSRepository : IPOSRepository
    {
        private myPoSContext _poscontext;
        public POSRepository(myPoSContext poscontext)
        {
            _poscontext = poscontext;
        }
        public IEnumerable<Person> GetPersons()
        {
            return _poscontext.Person.ToList();
        }

        public Person GetPersonById(string id)
        {
            return _poscontext.Person.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _poscontext.Customer.ToList();
        }

        public Customer GetCustomerById(string Id)
        {
            return _poscontext.Customer.FirstOrDefault(p => p.CustId == Id);
        }

        public IEnumerable<Product> GetProduct()
        {
            return _poscontext.Product.ToList();
        }
        public Product SaveProduct([FromBody] Product req)
        {

            var _idGen = new Genetate();
            
            var product = new Product
            {
                ProdId = _idGen.GenerateNumber("prod"),
                Name = req.Name,
                Description = req.Description
            };
            _poscontext.Product.Add(product);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return product;
        }
        public Product UpdateProduct(string id, [FromBody] Product req)
        {

            var product = new Product
            {
                ProdId = id,
                Name = req.Name,
                Description = req.Description
            };
            _poscontext.Product.Update(product);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return product;
        }
        public Product GetProductById(string Id)
        {
            return _poscontext.Product.FirstOrDefault(p => p.ProdId == Id);
        }
        public Product DeleteProduct(string Id)
        {
            var prod = GetProductById(Id);
            _poscontext.Product.Remove(prod);
            _poscontext.SaveChanges();
            return prod;
        }

        public IEnumerable<Item> GetItem()
        {
            return _poscontext.Item.Include(p=> p.Product).ToList();
        }
        public string SaveItem([FromBody] Item req)
        {

            var _idGen = new Genetate();
            var itemId = _idGen.GenerateNumber("I");
            var product = SaveProduct(req.Product);
            var nItem = new Item
            {
                ItemId = itemId,
                ProductId = product.ProdId,
                CostPrice = req.CostPrice,
                SalsePrice = req.SalsePrice
            };
            

            _poscontext.Item.Add(nItem);
            _poscontext.SaveChanges();
            return itemId;
        }
        public Item UpdateItem(string id, [FromBody] Item req)
        {

            UpdateProduct(req.ProductId, req.Product);
            _poscontext.Item.Update(req);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return req;
        }
        public Item GetItemById(string Id)
        {
            return _poscontext.Item.FirstOrDefault(p => p.ItemId == Id);
        }
        public Item DeleteItem(string Id)
        {
            var prod = GetItemById(Id);
            _poscontext.Item.Remove(prod);
            _poscontext.SaveChanges();
            return prod;
        }

    }
}
