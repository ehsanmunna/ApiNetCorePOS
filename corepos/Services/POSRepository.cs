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
            return _poscontext.Customer.Include(p=>p.Person).ToList();
        }

        public Customer GetCustomerById(string Id)
        {
            return _poscontext.Customer.FirstOrDefault(p => p.CustId == Id);
        }

        public Customer SaveCustomer([FromBody] Customer req)
        {
            var _idGen = new Genetate();
            var personId = _idGen.GenerateNumber("P");
            req.CustId = _idGen.GenerateNumber("C");
            req.PersonId = personId;
            req.Person.Id = personId;
            //_poscontext.Person.Add(req.Person);
            _poscontext.Customer.Add(req);
            _poscontext.SaveChanges();
            return req;
        }

        public Customer UpdateCustomer([FromBody] Customer data)
        {
            _poscontext.Customer.Update(data);
            _poscontext.SaveChanges();
            return data;
        }

        public IEnumerable<Product> GetProduct()
        {
            return _poscontext.Product.ToList();
        }
        public Product SaveProduct([FromBody] Product req)
        {

            var _idGen = new Genetate();
            req.ProdId = _idGen.GenerateNumber("prod");
            //var product = new Product
            //{
            //    ProdId = _idGen.GenerateNumber("prod"),
            //    Name = req.Name,
            //    RetailPrice = req.RetailPrice,
            //    WholeSalePrice = req.WholeSalePrice,
            //    Description = req.Description
            //};
            _poscontext.Product.Add(req);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return req;
        }
        public Product UpdateProduct(string id, [FromBody] Product req)
        {

            //var product = new Product
            //{
            //    ProdId = id,
            //    Name = req.Name,
            //    Description = req.Description
            //};
            _poscontext.Product.Update(req);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return req;
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

        public IEnumerable<Stock> GetStock()
        {
            return _poscontext.Stock.Include(p=> p.Product).ToList();
        }
        public string SaveStock([FromBody] Stock req)
        {

            var _idGen = new Genetate();
            var itemId = _idGen.GenerateNumber("I");
            var product = SaveProduct(req.Product);
            var nItem = new Stock
            {
                StockId = itemId,
                ProductId = product.ProdId
            };
            

            _poscontext.Stock.Add(nItem);
            _poscontext.SaveChanges();
            return itemId;
        }
        public Stock UpdateStock(string id, [FromBody] Stock req)
        {

            UpdateProduct(req.ProductId, req.Product);
            _poscontext.Stock.Update(req);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return req;
        }
        public Stock GetStockById(string Id)
        {
            return _poscontext.Stock.FirstOrDefault(p => p.StockId == Id);
        }
        public Stock DeleteStock(string Id)
        {
            var prod = GetStockById(Id);
            _poscontext.Stock.Remove(prod);
            _poscontext.SaveChanges();
            return prod;
        }

        
    }
}
