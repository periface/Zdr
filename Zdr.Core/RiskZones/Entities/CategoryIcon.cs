using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Zdr.RiskZones.Entities
{
    public class CategoryIcon : FullAuditedEntity
    {
        public MapZoneCategory MapZoneCategory { get; protected set; }
        public virtual ICollection<MapZone> MapZones { get; set; }
        protected CategoryIcon()
        {

        }
        public string IconUrl { get; set; }
    }
}
