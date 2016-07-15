using Abp.Application.Services.Dto;

namespace Zdr.RiskZones.Dtos
{
    public class RiskZonePositionDto : EntityDto
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Icon { get; set; }
    }
}
