using System.Threading.Tasks;
using Abp.Application.Services;
using Zdr.RiskZones.Dtos;

namespace Zdr.RiskZones
{
    public interface IRiskZoneAppService : IApplicationService
    {
        Task<int> CreateZone(RiskZoneInputDto input);
        RiskZoneInputDto GetZoneForEdit(int id);
        RiskZonesOutput GetRiskZonesByStateAndCity(string state, string city);
    }
}
