using Abp.UI;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
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
            if (Request.Files.Count <= 0) throw new UserFriendlyException("Falta imagen");
            model.Images = new List<HttpPostedFileBase>();
            for (var i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                model.Images.Add(file);
            }
            var id = await _riskZoneAppService.CreateZone(model);
            return Json(id);
        }
    }
}