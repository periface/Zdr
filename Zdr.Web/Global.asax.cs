﻿using Abp;
using Abp.Web;
using Castle.Facilities.Logging;
using System;

namespace Zdr.Web
{
    public class MvcApplication : AbpWebApplication<ZdrWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
