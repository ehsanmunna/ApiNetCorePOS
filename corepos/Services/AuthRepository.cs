using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corepos.Entities;
using corepos.Helper;
using corepos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace corepos.Services
{
    public class AuthRepository : IAuthRepository
    {
        private myPoSContext _poscontext;
        public AuthRepository(myPoSContext poscontext)
        {
            _poscontext = poscontext;
        }
        //Authorization Repository
        public IEnumerable<PosUser> GetPosUser()
        {
            var user = _poscontext.PosUser
                .Include(s => s.Person)
            .ToList();
            return user;
        }

        public PosUser GetPosUserById(string id)
        {
            var user = _poscontext.PosUser
                .Include(s => s.Person)
                .FirstOrDefault(s => s.UserId == id);
            return user;
        }

        public PosUser GetPosUserByUserName(string username)
        {
            var user = _poscontext.PosUser
                .Include(s => s.Person)
                .FirstOrDefault(s => s.UserName == username);
            return user;
        }

        //public bool Login([FromBody] LoginDto req)
        //{
        //    var isLogged = false;
        //    var user = GetPosUserByUserName(req.UserName);
        //    if (user == null)
        //    {
        //        return isLogged;
        //    }

        //    if (user.Password == req.Password)
        //    {
        //        isLogged = true;
        //    }

        //    return isLogged;
        //}

        public string SavePosUser([FromBody] PosUserFormDto req)
        {
            var _idGen = new Genetate();
            var personId = _idGen.GenerateNumber("P");
            var person = new Person
            {
                Id = personId,
                FirstName = req.Person.FirstName,
                LastName = req.Person.LastName,
                Mobile = req.Person.Mobile,
                Address = req.Person.Address
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

        

        public PosUserViewDto UpdatePosUser(string Id, [FromBody] PosUserViewDto req)
        {
            var person = new Person
            {
                Id = req.PersonId,
                FirstName = req.Person.FirstName,
                LastName = req.Person.LastName,
                Mobile = req.Person.Mobile,
                Address = req.Person.Address,
                Email = req.Person.Email
            };
            _poscontext.Person.Update(person);

            var user = new PosUser
            {
                UserId = req.UserId,
                UserName = req.UserName,
                PersonId = req.PersonId
            };
            _poscontext.PosUser.Update(user);
            _poscontext.SaveChanges();
            return req;
        }

        
    }
}
