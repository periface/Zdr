using Abp.AutoMapper;
using Abp.Modules;
using ImageSaver;
using System.Reflection;

namespace Zdr
{
    [DependsOn(typeof(ZdrCoreModule), typeof(AbpAutoMapperModule), typeof(ImageSaverModule))]
    public class ZdrApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
