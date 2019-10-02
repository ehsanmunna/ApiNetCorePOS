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

        IEnumerable<ProductGroup> GetProductGroups();
        ProductGroup GetProductGroupById(int Id);
        ProductGroup SaveProductGroup([FromBody] ProductGroup data);
        ProductGroup UpdateProductGroup([FromBody] ProductGroup data);

        IEnumerable<MeasurementUnit> GetUnits();
        MeasurementUnit GetUnitId(int Id);
        MeasurementUnit SaveUnit([FromBody] MeasurementUnit data);
        MeasurementUnit UpdateUnit([FromBody] MeasurementUnit data);

        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplierId(string Id);
        Supplier SaveSupplier([FromBody] Supplier data);
        Supplier UpdateSupplier([FromBody] Supplier data);

        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(string Id);
        Customer SaveCustomer([FromBody] Customer data);
        Customer UpdateCustomer([FromBody] Customer data);

        IEnumerable<Product> GetProduct();
        Product GetProductById(string Id);
        Product SaveProduct([FromBody] Product data);
        Product UpdateProduct(string id, [FromBody] Product data);
        Product DeleteProduct(string id);

        IEnumerable<SalesMain> GetSales();
        SalesMain GetSalesById(string Id);
        SalesMain SaveSales([FromBody] SalesMain data);
        SalesMain UpdateSales([FromBody] SalesMain data);
        SalesMain DeleteSales(string id);

        IEnumerable<Stock> GetStock();
        Stock GetStockById(string Id);
        string SaveStock([FromBody] Stock data);
        Stock UpdateStock(string id, [FromBody] Stock data);
        Stock DeleteStock(string id);
        ////Authorization Repository
        //IEnumerable<PosUser> GetPosUser();
        //PosUser GetPosUserById(string id);
        //string SavePosUser([FromBody] PosUserFormDto req);
        //PosUserViewDto UpdatePosUser(string Id, [FromBody] PosUserFormDto req);
    }
}
