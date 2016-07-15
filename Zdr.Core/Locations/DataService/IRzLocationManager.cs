using Abp.Domain.Services;
using System.Threading.Tasks;
using Zdr.Locations.Entities;

namespace Zdr.Locations.DataService
{
    public interface IRzLocationManager : IDomainService
    {
        Task<Country> CreateCountry(Country country);
        Task<State> CreateState(State state);
        Task<City> CreateCity(City city);
    }
}
