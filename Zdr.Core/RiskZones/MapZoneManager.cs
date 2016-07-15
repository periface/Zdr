using Abp.Domain.Repositories;
using Helpers;
using System.Collections.Generic;
using System.Linq;
using Zdr.RiskZones.DataService;
using Zdr.RiskZones.Entities;
using Zdr.RiskZones.Policy;

namespace Zdr.RiskZones
{
    public class MapZoneManager : RzZoneManager
    {
        private readonly IRepository<MapZone> _mapZoneRepository;
        public MapZoneManager(IRepository<MapZone> mapZoneRepository, IMapZonePolicy mapZonePolicy, IRepository<MapZoneCategory> mapZoneCategoryRepository, IRepository<MapZoneGallery> mapZoneGalleryRepository, IRepository<MapZone> mapZoneRepository1) : base(mapZoneRepository, mapZonePolicy, mapZoneCategoryRepository, mapZoneGalleryRepository)
        {
            _mapZoneRepository = mapZoneRepository1;
        }

        public List<MapZone> GetZones(string cityCode)
        {
            var sluggedCityCode = cityCode.ToSlug();
            var zones = _mapZoneRepository.GetAll().Where(a => a.City.CityCode.ToUpper() == sluggedCityCode.ToUpper()).ToList();
            return zones;
        }
    }
}
