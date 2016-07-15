using Abp.Application.Services;
using System.Threading.Tasks;
using Zdr.RiskZones.Dtos;

namespace Zdr.RiskZones
{
    public interface IRiskZoneAppService : IApplicationService
    {
        Task<int> CreateZone(RiskZoneInputDto input);
        RiskZoneInputDto GetZoneForEdit(int id);
        RiskZonesOutput GetRiskZonesByCity(string cityCode);
    }
}
