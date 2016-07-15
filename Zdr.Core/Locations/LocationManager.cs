using Abp.Domain.Repositories;
using Zdr.Locations.DataService;
using Zdr.Locations.Entities;
using Zdr.Locations.Policy;

namespace Zdr.Locations
{
    public class LocationManager : RzLocationManager
    {
        public LocationManager(IRepository<Country> countryRepository,
            IRepository<City> cityRepository,
            IRepository<State> stateRepository,
            ILocationPolicy locationPolicy)
            : base(countryRepository,
                  cityRepository,
                  stateRepository,
                  locationPolicy)
        {
        }
    }
}
