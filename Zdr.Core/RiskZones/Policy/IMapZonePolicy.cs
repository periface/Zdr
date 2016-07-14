using Abp.Domain.Services;
using Zdr.RiskZones.Entities;

namespace Zdr.RiskZones.Policy
{
    public interface IMapZonePolicy : IDomainService
    {
        void CheckZoneData(MapZone zone);

    }
}
