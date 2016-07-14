using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zdr.RiskZones.Entities;
using Zdr.RiskZones.Policy;

namespace Zdr.RiskZones.DataService
{
    public class RzZoneManager : DomainService, IRzZoneManager
    {
        private readonly IRepository<MapZone> _mapZoneRepository;
        private readonly IMapZonePolicy _mapZonePolicy;
        public RzZoneManager(IRepository<MapZone> mapZoneRepository, IMapZonePolicy mapZonePolicy)
        {
            _mapZoneRepository = mapZoneRepository;
            _mapZonePolicy = mapZonePolicy;
        }

        public async Task<int> AddZone(MapZone zone)
        {
            _mapZonePolicy.CheckZoneData(zone);
            var id = await _mapZoneRepository.InsertOrUpdateAndGetIdAsync(zone);
            return id;
        }

        public Task<MapZone> GetZone(int zoneId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MapZone>> GetZones(bool includeUser = false)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveZone(MapZone zone)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveZone(int zoneId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MapZoneGallery>> GetMapZoneGallery(MapZone mapZone)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MapZoneGallery>> GetMapZoneGallery(int mapZoneId)
        {
            throw new System.NotImplementedException();
        }

        public Task AddImageToGallery(MapZoneGallery image)
        {
            throw new System.NotImplementedException();
        }
    }
}
