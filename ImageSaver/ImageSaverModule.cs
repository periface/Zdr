using Abp.Modules;
using FileSaver;
using System.Reflection;

namespace ImageSaver
{
    [DependsOn(typeof(FileManagerModule))]
    public class ImageSaverModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
