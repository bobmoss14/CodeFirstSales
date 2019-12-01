using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstSales
{
   public class BaseEntity
    {
        [DefaultValue(1)]
        public bool IsActive { get; set; }
      
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime CreatedOn { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime UpdatedOn { get; set; }
    }
}
