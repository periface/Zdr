using Abp.Domain.Repositories;
using Zdr.Locations.Entities;

namespace Zdr.Locations.Policy
{
    public class LocationPolicy : ILocationPolicy
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<State> _stateRepository;

        public LocationPolicy(IRepository<Country> countryRepository, IRepository<City> cityRepository, IRepository<State> stateRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
        }

        public bool IsCountryAlreadyCreated(Country country, out Country countryResolved)
        {
            var countryFound = _countryRepository.FirstOrDefault(a =>
                a.CountryCode.ToUpper().Equals(country.CountryCode.ToUpper()));
            countryResolved = countryFound;
            return countryFound != null;
        }

        public bool IsCityAlreadyCreated(City city, out City cityResolved)
        {
            var cityFound =
                _cityRepository.FirstOrDefault(a =>
                a.CityCode.ToUpper().Equals(city.CityCode.ToUpper()));
            cityResolved = cityFound;
            return cityFound != null;
        }

        public bool IsStateAlreadyCreated(State state, out State stateResolved)
        {
            var stateFound =
                _stateRepository.FirstOrDefault(a =>
                a.StateCode.ToUpper().Equals(state.StateCode.ToUpper()));
            stateResolved = stateFound;
            return stateFound != null;
        }
    }
}
