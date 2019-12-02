using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeFirstSales.Classes;

namespace CodeFirstSales
{
    [Table("Customers", Schema = "Sales")]
    public class Customer  : BaseEntity
    {
        public Customer()
        {
            _addresses = new List<Address>();
        }
        private ICollection<Address> _addresses;
        public int CustomerId { get; set; }
        [StringLength(50)]
        [Index("IX_FirstAnLastName", 2, IsUnique = false)]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Index("IX_FirstAnLastName", 1, IsUnique = false)]
        public string LastName { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }
        public virtual ICollection<Address> Addresses
        {
            get => _addresses;
            set => _addresses = value;
        }
    }
}
