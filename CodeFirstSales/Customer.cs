using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CodeFirstSales
{
    public class Customer  : BaseEntity
    {
        public int CustomerId { get; set; }
        [StringLength(50)]
        [Index("IX_FirstAnLastName", 2, IsUnique = false)]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Index("IX_FirstAnLastName", 1, IsUnique = false)]
        public string LastName { get; set; }
    }
}
