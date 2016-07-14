using Abp.UI;
using Zdr.RiskZones.Entities;

namespace Zdr.RiskZones.Policy
{
    public class MapZonePolicy : IMapZonePolicy
    {
        //These are internal errors they should not trigger if the application services are correctly implemented


        public void CheckZoneData(MapZone zone)
        {
            if (zone.Latitude <= 0 || zone.Longitude <= 0)
                throw new UserFriendlyException("Latitude or longitude not found");
            if (string.IsNullOrEmpty(zone.Content))
                throw new UserFriendlyException("Content not set for the zone");
            if (zone.User == null)
                throw new UserFriendlyException("User not found");
            if (zone.User.Id != 0)
                throw new UserFriendlyException("User not found");
        }
    }
}
