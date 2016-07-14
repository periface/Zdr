using Abp.Domain.Repositories;
using Zdr.RiskZones.DataService;
using Zdr.RiskZones.Entities;
using Zdr.RiskZones.Policy;

namespace Zdr.RiskZones
{
    public class MapZoneManager : RzZoneManager
    {
        public MapZoneManager(IRepository<MapZone> mapZoneRepository, IMapZonePolicy mapZonePolicy) : base(mapZoneRepository, mapZonePolicy)
        {
        }
    }
}
