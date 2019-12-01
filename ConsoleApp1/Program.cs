using System;
using System.Data.Entity;
using System.Linq;
using SalesEf;
using SalesEf.Migrations;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<Sales, Configuration>());

          //  Database.SetInitializer(new DropCreateDatabaseAlways<Sales>());
                GetCustomers();
            }

            private static void GetCustomers()
            {
                using (var context = new Sales())
                {
                    var customers = context.Customers.ToList();
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer.FirstName);
                    }
                }
            }
        
    }
}
