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

        IEnumerable<Product> GetProduct();
        Product GetProductById(string Id);
        Product SaveProduct([FromBody] Product data);
        Product UpdateProduct(string id, [FromBody] Product data);
        Product DeleteProduct(string id);

        IEnumerable<Item> GetItem();
        Item GetItemById(string Id);
        string SaveItem([FromBody] Item data);
        Item UpdateItem(string id, [FromBody] Item data);
        Item DeleteItem(string id);
        ////Authorization Repository
        //IEnumerable<PosUser> GetPosUser();
        //PosUser GetPosUserById(string id);
        //string SavePosUser([FromBody] PosUserFormDto req);
        //PosUserViewDto UpdatePosUser(string Id, [FromBody] PosUserFormDto req);
    }
}
