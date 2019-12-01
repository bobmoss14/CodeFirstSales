using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeFirstSales;
using SalesEf;

namespace WebApp.Controllers
{
    public class CustomersController : ApiController
    {
        private static readonly Sales Context = new Sales();
        // GET: api/Customers
        public IEnumerable<Customer> Get()
        {
            var customers = Context.Customers.AsNoTracking().ToList();
            return customers;
        }

        // GET: api/Customers/5
        public Customer Get(int id)
        {
            var customer = Context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == id);
            return customer;
        }

        // POST: api/Customers
        public void Post([FromBody]Customer value)
        {
           
            Context.Customers.Add(value);
            Context.SaveChanges();

        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]Customer value)
        {
           // Context.Customers.Attach(value);
         //  Context.Entry(value).State = EntityState.Modified;
            Context.Customers.AddOrUpdate(value);
            Context.SaveChanges();

        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
          var customer=  Context.Customers.FirstOrDefault(c => c.CustomerId == id);
          Context.Customers.Remove(customer ?? throw new InvalidOperationException());
          Context.SaveChanges();
        }
    }
}
