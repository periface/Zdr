using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Zdr.RiskZones.Entities
{
    public class MapZoneCategory : FullAuditedEntity
    {
        protected MapZoneCategory()
        {

        }
        public string CategoryName { get; protected set; }
        public string CategoryDescription { get; protected set; }
        public string CategoryImage { get; protected set; }
        public virtual ICollection<MapZone> MapZones { get; set; }
        public virtual ICollection<CategoryIcon> CategoryIcons { get; set; }

        public static MapZoneCategory CreateCategory(string categoryName, string categoryDescription, string categoryImage)
        {
            return new MapZoneCategory()
            {
                CategoryName = categoryName,
                CategoryDescription = categoryDescription,
                CategoryImage = categoryImage
            };
        }
    }
}
