﻿using corepos.Entities;
using corepos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Services
{
    public interface IAuthRepository
    {
        //Authorization Repository
        IEnumerable<PosUser> GetPosUser();
        PosUser GetPosUserById(string id);
        PosUser GetPosUserByUserName(string username);
        string SavePosUser([FromBody] PosUser req);
        PosUser UpdatePosUser([FromBody] PosUser req);
        //bool Login([FromBody] LoginDto req);
    }
}
