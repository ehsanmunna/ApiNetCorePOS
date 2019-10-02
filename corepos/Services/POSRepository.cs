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
            var genId = new GenerateIds();
            req.CustId = genId.GetCustomerId();
            if (req.PersonId == null)
            {
                var personId = genId.GetPersonId();
                req.PersonId = personId;
                req.Person.Id = personId;
            }
            
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
            return _poscontext.Product
                .Include(g => g.Group)
                .Include(s => s.Supplier)
                .Include(s => s.Supplier.Person)
                .Include(u => u.Unit)
                .ToList();
        }
        public Product SaveProduct([FromBody] Product req)
        {

            var _idGen = new GenerateIds();
            req.ProdId = _idGen.GetProductId();
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
            return _poscontext.Product
                .Include(g => g.Group)
                .Include(s => s.Supplier)
                .Include(p=>p.Supplier.Person)
                .Include(u => u.Unit)
                .FirstOrDefault(p => p.ProdId == Id);
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
            //return _poscontext.Stock.Include(p=> p.Product).ToList();
            return null;
        }
        public string SaveStock([FromBody] Stock req)
        {

            //var _idGen = new Genetate();
            //var itemId = _idGen.GenerateNumber("I");
            //var product = SaveProduct(req.Product);
            //var nItem = new Stock
            //{
            //    StockId = itemId,
            //    ProductId = product.ProdId
            //};


            //_poscontext.Stock.Add(nItem);
            //_poscontext.SaveChanges();
            //return itemId;
            return null;
        }
        public Stock UpdateStock(string id, [FromBody] Stock req)
        {

            UpdateProduct(req.ProductId, req.Product);
            //_poscontext.Stock.Update(req);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return req;
        }
        public Stock GetStockById(string Id)
        {
            //return _poscontext.Stock.FirstOrDefault(p => p.StockId == Id);
            return null;
        }
        public Stock DeleteStock(string Id)
        {
            var prod = GetStockById(Id);
            //_poscontext.Stock.Remove(prod);
            _poscontext.SaveChanges();
            return prod;
        }

        public IEnumerable<ProductGroup> GetProductGroups()
        {
            return _poscontext.ProductGroup.ToList();
        }

        public ProductGroup GetProductGroupById(int Id)
        {
            return _poscontext.ProductGroup.FirstOrDefault(s => s.Id == Id);
        }

        public ProductGroup SaveProductGroup([FromBody] ProductGroup data)
        {
            
            _poscontext.ProductGroup.Add(data);
            _poscontext.SaveChanges();
            return data;
        }

        public ProductGroup UpdateProductGroup([FromBody] ProductGroup data)
        {
            _poscontext.ProductGroup.Update(data);
            _poscontext.SaveChanges();
            return data;
        }

        public IEnumerable<MeasurementUnit> GetUnits()
        {
            return _poscontext.MeasurementUnit.ToList();
        }

        public MeasurementUnit GetUnitId(int Id)
        {
            return _poscontext.MeasurementUnit.FirstOrDefault(s => s.Id == Id);
        }

        public MeasurementUnit SaveUnit([FromBody] MeasurementUnit data)
        {
            _poscontext.MeasurementUnit.Add(data);
            _poscontext.SaveChanges();
            return data;
        }

        public MeasurementUnit UpdateUnit([FromBody] MeasurementUnit data)
        {
            _poscontext.MeasurementUnit.Update(data);
            _poscontext.SaveChanges();
            return data;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _poscontext.Supplier.Include(p => p.Person).ToList();
        }

        public Supplier GetSupplierId(string Id)
        {
            return _poscontext.Supplier.Include(p=> p.Person).FirstOrDefault(s => s.Id == Id);
        }

        public Supplier SaveSupplier([FromBody] Supplier data)
        {
            var genId = new GenerateIds();
            data.Id = genId.GetSupplierId();
            if (data.PersonId == null)
            {
                var personId = genId.GetPersonId();
                data.PersonId = personId;
                data.Person.Id = personId;
            }
            _poscontext.Supplier.Add(data);
            _poscontext.SaveChanges();
            return data;
        }

        public Supplier UpdateSupplier([FromBody] Supplier data)
        {
            _poscontext.Supplier.Update(data);
            _poscontext.SaveChanges();
            return data;
        }

        public IEnumerable<SalesMain> GetSales()
        {
            return _poscontext.SalesMain
                .Include(ss=> ss.SalesSub)
                .ToList();
        }

        public SalesMain GetSalesById(string Id)
        {
            return _poscontext.SalesMain
                .Include(ss => ss.SalesSub)
                .FirstOrDefault(s=> s.SalesId == Id);
        }

        public SalesMain SaveSales([FromBody] SalesMain data)
        {
            var genId = new GenerateIds();
            var _salesId = genId.GetSalseId();
            data.SalesId = _salesId;
            foreach (var item in data.SalesSub)
            {
                item.SalseId = _salesId;
            }
            _poscontext.SalesMain.Add(data);
            _poscontext.SaveChanges();
            return data;

        }

        public SalesMain UpdateSales([FromBody] SalesMain data)
        {
            _poscontext.SalesMain.Update(data);
            _poscontext.SaveChanges();
            return data;
        }

        public SalesMain DeleteSales(string id)
        {
            throw new NotImplementedException();
        }
    }
}
