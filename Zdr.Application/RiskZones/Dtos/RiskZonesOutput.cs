using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace Zdr.RiskZones.Dtos
{
    public class RiskZonesOutput
    {
        public List<RiskZonePositionDto> Positions { get; set; }
    }
}
