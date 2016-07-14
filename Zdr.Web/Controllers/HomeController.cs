using System.Threading.Tasks;
using System.Web.Mvc;
using Zdr.RiskZones;
using Zdr.RiskZones.Dtos;

namespace Zdr.Web.Controllers
{
    //[AbpMvcAuthorize]	//[AbpMvcAuthorize]
    public class HomeController : ZdrControllerBase
    {
        private readonly IRiskZoneAppService _riskZoneAppService;

        public HomeController(IRiskZoneAppService riskZoneAppService)
        {
            _riskZoneAppService = riskZoneAppService;
        }

        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
        [HttpPost]
        public async Task<ActionResult> CreateZone()
        {
            var model = Helpers.InputBuilder.BuildInputByRequest<RiskZoneInputDto>(Request, "Zdr");
            if (Request.Files.Count > 0)
            {
                await _riskZoneAppService.CreateZone(model);
            }
            return Json(null);
        }
    }
}