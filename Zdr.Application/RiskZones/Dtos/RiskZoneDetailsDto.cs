using Abp.Application.Services.Dto;

namespace Zdr.RiskZones.Dtos
{
    public class RiskZoneDetailsDto : EntityDto
    {
        public string Content { get; set; }
        public long? UserId { get; set; }
        public string UserName { get; set; }

    }
}
