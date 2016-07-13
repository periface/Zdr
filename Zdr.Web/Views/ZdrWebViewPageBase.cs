using Abp.Web.Mvc.Views;

namespace Zdr.Web.Views
{
    public abstract class ZdrWebViewPageBase : ZdrWebViewPageBase<dynamic>
    {

    }

    public abstract class ZdrWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ZdrWebViewPageBase()
        {
            LocalizationSourceName = ZdrConsts.LocalizationSourceName;
        }
    }
}