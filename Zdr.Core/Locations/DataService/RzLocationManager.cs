using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Threading.Tasks;
using Zdr.Locations.Entities;
using Zdr.Locations.Policy;

namespace Zdr.Locations.DataService
{
    public class RzLocationManager : DomainService, IRzLocationManager
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<State> _stateRepository;
        private readonly ILocationPolicy _locationPolicy;
        public RzLocationManager(IRepository<Country> countryRepository, IRepository<City> cityRepository, IRepository<State> stateRepository, ILocationPolicy locationPolicy)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
            _locationPolicy = locationPolicy;
        }

        public virtual async Task<Country> CreateCountry(Country country)
        {
            Country countryResolved;
            if (_locationPolicy.IsCountryAlreadyCreated(country, out countryResolved))
            {
                return countryResolved;
            }
            await _countryRepository.InsertOrUpdateAndGetIdAsync(country);
            await CurrentUnitOfWork.SaveChangesAsync();
            return country;
        }

        public virtual async Task<State> CreateState(State state)
        {
            State stateResolved;
            if (_locationPolicy.IsStateAlreadyCreated(state, out stateResolved))
            {
                return stateResolved;
            }
            await _stateRepository.InsertOrUpdateAndGetIdAsync(state);
            return state;
        }

        public virtual async Task<City> CreateCity(City city)
        {
            City cityResolved;
            if (_locationPolicy.IsCityAlreadyCreated(city, out cityResolved))
            {
                return cityResolved;
            }
            await _cityRepository.InsertOrUpdateAndGetIdAsync(city);
            return city;
        }
    }
}
