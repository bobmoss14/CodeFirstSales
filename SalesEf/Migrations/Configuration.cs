using System.Collections.Generic;
using CodeFirstSales;
using CodeFirstSales.Classes;

namespace SalesEf.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SalesEf.Sales>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Sales";
            this.AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(SalesEf.Sales context)
        {
#if true
            context.Database.ExecuteSqlCommand("DELETE Marketing.ContactDetails");
            context.Database.ExecuteSqlCommand("DELETE Sales.Customers");
            IList<Customer> defaultStandards = new List<Customer>();
            var customerContactDetail1 = new ContactDetail()
            {
                Facebook = "FB",
                HomePhone = "123",
                LinkedIn = "LI",
                MobilePhone = "4444",
                Messenger = "Msg",
                OfficePhone = "999"
            };

            var addresses1 = new List<Address>()
            {
                new Address()
                {
                    AddressType = AddressType.Billing, City = "SO", PostalCode = "91403", StateProvince = "CA",
                    Street = "14817 Sutton st."
                },
                new Address()
                {
                    AddressType = AddressType.ShippingSecondary, City = "VN", PostalCode = "91407",
                    StateProvince = "CA", Street = "12618 Hattress st."
                },
                new Address()
                {
                    AddressType = AddressType.ShippingSecondary, City = "PP", PostalCode = "91507",
                    StateProvince = "CA", Street = "1750 Pacific p. Parkway"
                }
            };

            var firstCustomer = new Customer() {FirstName = "Bob", LastName = "Mossanen", ContactDetail = customerContactDetail1, Addresses = addresses1};

            defaultStandards.Add(firstCustomer);
            defaultStandards.Add(new Customer() { FirstName = "Bob", LastName = "Mossanen" });
            defaultStandards.Add(new Customer() { FirstName = "Shelly", LastName = "Moss" });
            defaultStandards.Add(new Customer() { FirstName = "Bonnie", LastName = "Molavi" });

            context.Customers.AddRange(defaultStandards);
           


            base.Seed(context);
#endif
        }
    }
}
