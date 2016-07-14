using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using Zdr.RiskZones.Entities;

namespace Zdr.Locations.Entities
{
    public class City : FullAuditedEntity
    {
        public virtual State State { get; set; }
        public string CityCode { get; set; }
        public string CityFullName { get; set; }
        public ICollection<MapZone> MapZones { get; set; }
    }
}