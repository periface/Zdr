using Abp.Application.Services.Dto;

namespace Zdr.RiskZones.Dtos
{
    public class RiskZonePositionDto : EntityDto
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Icon { get; set; }
    }
}
