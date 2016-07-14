using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Web;

namespace Zdr.RiskZones.Dtos
{
    public class RiskZoneInputDto : IInputDto
    {
        public string Content { get; set; }
        public IEnumerable<HttpPostedFileBase> Images { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StateLongName { get; set; }
        public string CityLongName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
