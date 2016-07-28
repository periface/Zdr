using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Zdr.Locations.Entities;
using Zdr.RiskZones.HelperEntities;
using Zdr.Users;

namespace Zdr.RiskZones.Entities
{
    public class MapZone : FullAuditedEntity
    {
        protected MapZone()
        {

        }
        public City City { get; protected set; }
        public virtual CategoryIcon CategoryIcon { get; protected set; }
        public string Content { get; protected set; }
        public int ZoneType { get; protected set; }
        public string Latitude { get; protected set; }
        public string Longitude { get; protected set; }
        public DbGeography Location { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual ICollection<MapZoneGallery> MapZoneGalleries { get; set; }
        public static MapZone CreateZone(MapZoneEntityCreationObject input)
        {
            return new MapZone()
            {
                Content = input.Content,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                User = input.User,
                Category = input.Category,
                CategoryIcon = input.Icon,
                ZoneType = input.ZoneType,
                City = input.City,
                Location = SetLocationCoordinates(input)
            };
        }

        private static DbGeography SetLocationCoordinates(MapZoneEntityCreationObject input)
        {
            var point = $"POINT({input.Longitude} {input.Latitude})";
            return DbGeography.PointFromText(point, 4326);
        }

        public virtual MapZoneCategory Category { get; protected set; }
    }
}
