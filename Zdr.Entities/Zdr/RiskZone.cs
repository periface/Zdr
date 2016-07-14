using Abp.Domain.Entities.Auditing;

namespace Zdr.Entities.Zdr
{
    public class RiskZone : FullAuditedEntity
    {
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
