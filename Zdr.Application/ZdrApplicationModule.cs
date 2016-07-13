using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Zdr
{
    [DependsOn(typeof(ZdrCoreModule), typeof(AbpAutoMapperModule))]
    public class ZdrApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
