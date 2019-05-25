using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corepos.Entities;
using corepos.Models;
using Microsoft.AspNetCore.Mvc;
using corepos.Helper;

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

        //Authorization Repository
        public IEnumerable<PosUserViewDto> GetPosUser()
        {
            var user = _poscontext.PosUser
                .Select(res => new PosUserViewDto
            {
                UserId = res.UserId,
                UserName = res.UserName,
                FirstName = res.Person.FirstName,
                LastName = res.Person.LastName,
                Mobile = res.Person.Mobile,
                Address = res.Person.Address
            })
            .ToList();
            return user;
        }
        public string SavePosUser([FromBody] PosUserFormDto req)
        {
            var _idGen = new Genetate();
            var personId = _idGen.GenerateNumber("P");
            var person = new Person
            {
                Id = personId,
                FirstName = req.FirstName,
                LastName = req.LastName,
                Mobile = req.Mobile,
                Address = req.Address
            };
            _poscontext.Person.Add(person);

            var userId = _idGen.GenerateNumber("U");
            var user = new PosUser
            {
                UserId = userId,
                PersonId = personId,
                UserName = req.UserName,
                Password = req.Password
            };
            _poscontext.PosUser.Add(user);
            _poscontext.SaveChanges();
            //_poscontext.Person
            return userId;
        }

        public PosUserViewDto UpdatePosUser(string Id, [FromBody] PosUserFormDto req)
        {
            var person = new Person
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Mobile = req.Mobile,
                Address = req.Address
            };
            _poscontext.Person.Update(person);

            var user = new PosUser
            {
                UserName = req.UserName
            };
            _poscontext.PosUser.Update(user);
            _poscontext.SaveChanges();
            return req;
        }
    }
}
