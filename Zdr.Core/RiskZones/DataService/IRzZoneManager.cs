using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zdr.RiskZones.Entities;

namespace Zdr.RiskZones.DataService
{
    public interface IRzZoneManager : IDomainService
    {
        Task<int> AddZone(MapZone zone);
        Task<MapZone> GetZone(int zoneId);
        Task<List<MapZone>> GetZones(bool includeUser = false);
        Task RemoveZone(MapZone zone);
        Task RemoveZone(int zoneId);
        Task<List<MapZoneGallery>> GetMapZoneGallery(MapZone mapZone);
        Task<List<MapZoneGallery>> GetMapZoneGallery(int mapZoneId);
        Task AddImageToGallery(MapZoneGallery image);

    }
}
