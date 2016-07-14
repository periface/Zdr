using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Zdr.Locations.Entities
{
    public class State : FullAuditedEntity
    {
        public virtual Country Country { get; set; }
        public string StateFullName { get; set; }
        public string StateCode { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
