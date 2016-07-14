using Abp.Zero.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using Zdr.Authorization.Roles;
using Zdr.Locations.Entities;
using Zdr.MultiTenancy;
using Zdr.RiskZones.Entities;
using Zdr.Users;

namespace Zdr.EntityFramework
{
    public class ZdrDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<MapZone> MapZones { get; set; }
        public IDbSet<MapZoneCategory> MapZoneCategories { get; set; }
        public IDbSet<MapZoneGallery> MapZoneGalleries { get; set; }
        public IDbSet<CategoryIcon> CategoryIcons { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<State> States { get; set; }
        public IDbSet<City> Cities { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ZdrDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ZdrDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ZdrDbContext since ABP automatically handles it.
         */
        public ZdrDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ZdrDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
