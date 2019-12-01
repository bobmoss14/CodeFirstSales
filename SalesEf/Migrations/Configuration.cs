using System.Collections.Generic;
using CodeFirstSales;

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
          
            context.Database.ExecuteSqlCommand("DELETE Customers");
            IList<Customer> defaultStandards = new List<Customer>();

            defaultStandards.Add(new Customer() { FirstName = "Bob", LastName = "Mossanen" });
            defaultStandards.Add(new Customer() { FirstName = "Shelly", LastName = "Moss" });
            defaultStandards.Add(new Customer() { FirstName = "Bonnie", LastName = "Molavi" });

            context.Customers.AddRange(defaultStandards);

            base.Seed(context);
#endif
        }
    }
}
