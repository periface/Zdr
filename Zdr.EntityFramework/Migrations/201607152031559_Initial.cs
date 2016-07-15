namespace Zdr.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryIcons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IconUrl = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        MapZoneCategory_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CategoryIcon_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MapZoneCategories", t => t.MapZoneCategory_Id)
                .Index(t => t.MapZoneCategory_Id);
            
            CreateTable(
                "dbo.MapZoneCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                        CategoryImage = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MapZoneCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MapZones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ZoneType = c.Int(nullable: false),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Category_Id = c.Int(),
                        CategoryIcon_Id = c.Int(),
                        City_Id = c.Int(),
                        User_Id = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MapZone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MapZoneCategories", t => t.Category_Id)
                .ForeignKey("dbo.CategoryIcons", t => t.CategoryIcon_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CategoryIcon_Id)
                .Index(t => t.City_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityCode = c.String(),
                        CityFullName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        State_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_City_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateFullName = c.String(),
                        StateCode = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Country_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_State_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        CountryFullName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Country_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MapZoneGalleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        SmallImage = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        MapZone_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MapZoneGallery_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MapZones", t => t.MapZone_Id)
                .Index(t => t.MapZone_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapZones", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.MapZoneGalleries", "MapZone_Id", "dbo.MapZones");
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Cities", "State_Id", "dbo.States");
            DropForeignKey("dbo.MapZones", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.MapZones", "CategoryIcon_Id", "dbo.CategoryIcons");
            DropForeignKey("dbo.MapZones", "Category_Id", "dbo.MapZoneCategories");
            DropForeignKey("dbo.CategoryIcons", "MapZoneCategory_Id", "dbo.MapZoneCategories");
            DropIndex("dbo.MapZoneGalleries", new[] { "MapZone_Id" });
            DropIndex("dbo.States", new[] { "Country_Id" });
            DropIndex("dbo.Cities", new[] { "State_Id" });
            DropIndex("dbo.MapZones", new[] { "User_Id" });
            DropIndex("dbo.MapZones", new[] { "City_Id" });
            DropIndex("dbo.MapZones", new[] { "CategoryIcon_Id" });
            DropIndex("dbo.MapZones", new[] { "Category_Id" });
            DropIndex("dbo.CategoryIcons", new[] { "MapZoneCategory_Id" });
            DropTable("dbo.MapZoneGalleries",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MapZoneGallery_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Countries",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Country_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.States",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_State_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Cities",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_City_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.MapZones",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MapZone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.MapZoneCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MapZoneCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CategoryIcons",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CategoryIcon_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
