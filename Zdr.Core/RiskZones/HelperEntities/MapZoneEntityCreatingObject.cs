﻿using Zdr.Locations.Entities;
using Zdr.RiskZones.Entities;
using Zdr.Users;

namespace Zdr.RiskZones.HelperEntities
{
    public class MapZoneEntityCreatingObject
    {
        public string Content { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public User User { get; set; }
        public MapZoneCategory Category { get; set; }
        public CategoryIcon Icon { get; set; }
        public int ZoneType { get; set; }
        public City City { get; set; }
    }
}