using Castle.Components.DictionaryAdapter;
using System.Collections.Generic;
using System.Web;

namespace Zdr.RiskZones.Dtos
{
    public class RiskZoneInputDto
    {
        public RiskZoneInputDto()
        {
            Images = new EditableList<HttpPostedFileBase>();
        }
        public string Content { get; set; }
        public List<HttpPostedFileBase> Images { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string StateLongName { get; set; }
        public string CityLongName { get; set; }
        public string CountryLongName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public HttpFileCollectionBase RequestFiles { get; set; }
    }
}
