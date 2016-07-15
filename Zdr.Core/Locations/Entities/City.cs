using Abp.Domain.Entities.Auditing;
using Helpers;
using System.Collections.Generic;
using Zdr.RiskZones.Entities;

namespace Zdr.Locations.Entities
{
    public class City : FullAuditedEntity
    {
        protected City()
        {

        }
        public virtual State State { get; protected set; }
        public string CityCode { get; protected set; }
        public string CityFullName { get; protected set; }
        public ICollection<MapZone> MapZones { get; set; }

        public static City CreateCity(string cityFullName, string cityCode, State state)
        {
            return new City()
            {
                CityCode = cityCode.ToSlug(),
                CityFullName = cityFullName,
                State = state
            };
        }
    }
}