using Abp.Domain.Entities.Auditing;
using Helpers;
using System.Collections.Generic;

namespace Zdr.Locations.Entities
{
    public class Country : FullAuditedEntity
    {
        protected Country()
        {

        }
        public string CountryCode { get; protected set; }
        public string CountryFullName { get; protected set; }
        public virtual ICollection<State> States { get; set; }

        public static Country CreateCountry(string countryFullName, string countryCode)
        {
            return new Country()
            {
                CountryFullName = countryFullName,
                CountryCode = countryCode.ToSlug()
            };
        }
    }
}