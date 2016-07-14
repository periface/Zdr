using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Zdr.Locations.Entities
{
    public class Country : FullAuditedEntity
    {
        public string CountryCode { get; set; }
        public string CountryFullName { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}