namespace SalesEf.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        IsActive = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "1")
                                },
                            }),
                        CreatedOn = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "getdate()")
                                },
                            }),
                        UpdatedOn = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "getdate()")
                                },
                            }),
                    })
                .PrimaryKey(t => t.CustomerId)
                .Index(t => new { t.LastName, t.FirstName }, name: "IX_FirstAnLastName");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", "IX_FirstAnLastName");
            DropTable("dbo.Customers",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedOn",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "getdate()" },
                        }
                    },
                    {
                        "IsActive",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "1" },
                        }
                    },
                    {
                        "UpdatedOn",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "getdate()" },
                        }
                    },
                });
        }
    }
}
