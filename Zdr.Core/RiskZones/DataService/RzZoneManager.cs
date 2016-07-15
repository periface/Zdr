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
        private readonly IRepository<MapZoneCategory> _mapZoneCategoryRepository;
        private readonly IRepository<MapZoneGallery> _mapZoneGalleryRepository;
        private readonly IMapZonePolicy _mapZonePolicy;
        public RzZoneManager(IRepository<MapZone> mapZoneRepository, IMapZonePolicy mapZonePolicy, IRepository<MapZoneCategory> mapZoneCategoryRepository, IRepository<MapZoneGallery> mapZoneGalleryRepository)
        {
            _mapZoneRepository = mapZoneRepository;
            _mapZonePolicy = mapZonePolicy;
            _mapZoneCategoryRepository = mapZoneCategoryRepository;
            _mapZoneGalleryRepository = mapZoneGalleryRepository;
        }

        public virtual async Task<int> AddZone(MapZone zone)
        {
            _mapZonePolicy.CheckZoneData(zone);
            var id = await _mapZoneRepository.InsertOrUpdateAndGetIdAsync(zone);
            return id;
        }

        public virtual MapZoneCategory GetCategory(int categoryId)
        {
            var category = _mapZoneCategoryRepository.FirstOrDefault(a => a.Id == categoryId);
            return category;
        }

        public virtual Task<MapZone> GetZone(int zoneId)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<List<MapZone>> GetZones(bool includeUser = false)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task RemoveZone(MapZone zone)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task RemoveZone(int zoneId)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<List<MapZoneGallery>> GetMapZoneGallery(MapZone mapZone)
        {
            throw new System.NotImplementedException();
        }

        public virtual Task<List<MapZoneGallery>> GetMapZoneGallery(int mapZoneId)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task AddImageToGallery(MapZoneGallery image)
        {
            await _mapZoneGalleryRepository.InsertOrUpdateAndGetIdAsync(image);
        }
    }
}
