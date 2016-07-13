using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Zdr.EntityFramework;

namespace Zdr.Migrator
{
    [DependsOn(typeof(ZdrDataModule))]
    public class ZdrMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ZdrDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}