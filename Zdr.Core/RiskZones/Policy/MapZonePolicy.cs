using Abp.UI;
using Zdr.RiskZones.Entities;

namespace Zdr.RiskZones.Policy
{
    public class MapZonePolicy : IMapZonePolicy
    {
        //These are internal errors they should not trigger if the application services are correctly implemented


        public void CheckZoneData(MapZone zone)
        {
            if (zone.Latitude.Equals(0) || zone.Longitude.Equals(0))
                throw new UserFriendlyException("Latitude or longitude not found");
            if (string.IsNullOrEmpty(zone.Content) && zone.ZoneType
                != (int)Enums.ZoneType.Fast)
                throw new UserFriendlyException("Content not set for the zone");
            if (zone.User == null)
                throw new UserFriendlyException("User not found");
            if (zone.User.Id == 0)
                throw new UserFriendlyException("User not found");
        }
    }
}
