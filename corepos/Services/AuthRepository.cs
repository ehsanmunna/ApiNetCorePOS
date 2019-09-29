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

        public string SavePosUser([FromBody] PosUser req)
        {
            var _idGen = new Genetate();
            var personId = _idGen.GenerateNumber("P");
            req.PersonId = personId;
            req.Person.Id = personId;
            req.UserId = _idGen.GenerateNumber("U");
            //_poscontext.Person.Add(req.Person);
            _poscontext.PosUser.Add(req);
            _poscontext.SaveChanges();
            return req.UserId;
        }

        

        public PosUser UpdatePosUser([FromBody] PosUser req)
        {
            _poscontext.PosUser.Update(req);
            _poscontext.SaveChanges();
            return req;
        }

        
    }
}
