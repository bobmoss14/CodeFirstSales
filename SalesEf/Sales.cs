using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using CodeFirstSales;

namespace SalesEf
{
    public partial class Sales: DbContext
    {
        public Sales()
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Customer> Customers { get; set;  }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<string>().Configure(p => p.IsUnicode(false));

            modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
            var convention = new AttributeToColumnAnnotationConvention<DefaultValueAttribute, string>("SqlDefaultValue",
                (p, attributes) => attributes.SingleOrDefault().Value.ToString());
            modelBuilder.Conventions.Add(convention);

        }
    }
}
