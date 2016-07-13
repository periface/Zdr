using System.Web.Mvc;

namespace Zdr.Web.Controllers
{
    //[AbpMvcAuthorize]	//[AbpMvcAuthorize]
    public class HomeController : ZdrControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
    }
}