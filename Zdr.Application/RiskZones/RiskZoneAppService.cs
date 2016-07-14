using Abp.Application.Services;
using System.Threading.Tasks;
using Zdr.RiskZones.Dtos;
using Zdr.RiskZones.Entities;
using Zdr.RiskZones.HelperEntities;

namespace Zdr.RiskZones
{
    public class RiskZoneAppService : ApplicationService, IRiskZoneAppService
    {
        private readonly MapZoneManager _mapZoneManager;

        public RiskZoneAppService(MapZoneManager mapZoneManager)
        {
            _mapZoneManager = mapZoneManager;
        }

        public async Task<int> CreateZone(RiskZoneInputDto input)
        {
            var id = await _mapZoneManager.AddZone(MapZone.CreateZone(new MapZoneEntityCreatingObject()
            {

            }));
            return id;
        }

        public RiskZoneInputDto GetZoneForEdit(int id)
        {
            throw new System.NotImplementedException();
        }

        public RiskZonesOutput GetRiskZonesByStateAndCity(string state, string city)
        {
            throw new System.NotImplementedException();
        }
    }
}
