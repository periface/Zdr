using Abp.Domain.Entities.Auditing;

namespace Zdr.RiskZones.Entities
{
    public class MapZoneGallery : FullAuditedEntity
    {
        protected MapZoneGallery()
        {

        }
        public string Image { get; protected set; }
        public virtual MapZone MapZone { get; protected set; }

        public static MapZoneGallery CreateMapZoneGallery(string fileName, MapZone mapZone)
        {
            return new MapZoneGallery()
            {
                Image = fileName,
                MapZone = mapZone
            };
        }
    }
}
