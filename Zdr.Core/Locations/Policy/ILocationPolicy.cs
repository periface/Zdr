using Abp.Domain.Services;
using Zdr.Locations.Entities;

namespace Zdr.Locations.Policy
{
    public interface ILocationPolicy : IDomainService
    {
        bool IsCountryAlreadyCreated(Country country, out Country countryResolved);
        bool IsCityAlreadyCreated(City city, out City cityResolved);
        bool IsStateAlreadyCreated(State state, out State stateResolved);
    }
}
