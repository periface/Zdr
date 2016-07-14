using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using Zdr.Users;

namespace Zdr.RiskZones.Entities
{
    public class MapZone : FullAuditedEntity
    {
        protected MapZone()
        {

        }
        public virtual CategoryIcon CategoryIcon { get; protected set; }
        public string Content { get; protected set; }

        public float Latitude { get; protected set; }
        public float Longitude { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual ICollection<MapZoneGallery> MapZoneGalleries { get; set; }

        public static MapZone CreateZone(string content, float latitude, float longitude, User user, MapZoneCategory category, CategoryIcon icon)
        {
            return new MapZone()
            {
                Content = content,
                Latitude = latitude,
                Longitude = longitude,
                User = user,
                Category = category,
                CategoryIcon = icon
            };
        }

        public MapZoneCategory Category { get; protected set; }
    }
}
