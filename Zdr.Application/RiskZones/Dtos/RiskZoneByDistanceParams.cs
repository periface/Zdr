using Helpers;

namespace Zdr.RiskZones.Dtos
{
    public class RiskZoneByDistanceParams
    {
        public Position Center { get; set; }
        public BoundsNorm Bounds { get; set; }
        public decimal Zoom { get; set; }
        public decimal BoundingRadius { get; set; }
    }
}
