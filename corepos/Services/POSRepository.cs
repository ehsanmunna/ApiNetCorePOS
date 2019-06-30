﻿using System;
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

        //Authorization Repository
        //public IEnumerable<PosUser> GetPosUser()
        //{
        //    var user = _poscontext.PosUser
        //        .Include(s => s.Person)
        //    .ToList();
        //    return user;
        //}

        //public PosUser GetPosUserById(string id)
        //{
        //    var user = _poscontext.PosUser
        //        .Include(s => s.Person)
        //        .FirstOrDefault(s => s.UserId == id);
        //    return user;
        //}

        //public string SavePosUser([FromBody] PosUserFormDto req)
        //{
        //    var _idGen = new Genetate();
        //    var personId = _idGen.GenerateNumber("P");
        //    var person = new Person
        //    {
        //        Id = personId,
        //        FirstName = req.Person.FirstName,
        //        LastName = req.Person.LastName,
        //        Mobile = req.Person.Mobile,
        //        Address = req.Person.Address
        //    };
        //    _poscontext.Person.Add(person);

        //    var userId = _idGen.GenerateNumber("U");
        //    var user = new PosUser
        //    {
        //        UserId = userId,
        //        PersonId = personId,
        //        UserName = req.UserName,
        //        Password = req.Password
        //    };
        //    _poscontext.PosUser.Add(user);
        //    _poscontext.SaveChanges();
        //    //_poscontext.Person
        //    return userId;
        //}

        //public PosUserViewDto UpdatePosUser(string Id, [FromBody] PosUserFormDto req)
        //{
        //    var person = new Person
        //    {
        //        FirstName = req.Person.FirstName,
        //        LastName = req.Person.LastName,
        //        Mobile = req.Person.Mobile,
        //        Address = req.Person.Address
        //    };
        //    _poscontext.Person.Update(person);

        //    var user = new PosUser
        //    {
        //        UserName = req.UserName
        //    };
        //    _poscontext.PosUser.Update(user);
        //    _poscontext.SaveChanges();
        //    return req;
        //}


    }
}
