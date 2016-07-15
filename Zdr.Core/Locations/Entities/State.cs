using Abp.Domain.Entities.Auditing;
using Helpers;
using System.Collections.Generic;

namespace Zdr.Locations.Entities
{
    public class State : FullAuditedEntity
    {
        protected State()
        {

        }
        public virtual Country Country { get; protected set; }
        public string StateFullName { get; protected set; }
        public string StateCode { get; protected set; }
        public virtual ICollection<City> Cities { get; set; }

        public static State CreateState(string fullName, string nameCode, Country country)
        {
            return new State()
            {
                StateFullName = fullName,
                StateCode = nameCode.ToSlug(),
                Country = country
            };
        }
    }
}
