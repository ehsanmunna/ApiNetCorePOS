using corepos.Entities;
using corepos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corepos.Services
{
    public interface IPOSRepository
    {
        IEnumerable<Person> GetPersons();
        Person GetPersonById(string Id);

        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(string Id);

        //Authorization Repository
        IEnumerable<PosUserViewDto> GetPosUser();
        string SavePosUser([FromBody] PosUserFormDto req);
        PosUserViewDto UpdatePosUser(string Id, [FromBody] PosUserFormDto req);
    }
}
