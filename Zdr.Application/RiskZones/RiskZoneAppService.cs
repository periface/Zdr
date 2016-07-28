using Abp.Application.Services;
using Abp.Authorization;
using Abp.UI;
using Helpers;
using ImageSaver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Zdr.Locations;
using Zdr.Locations.Entities;
using Zdr.RiskZones.Dtos;
using Zdr.RiskZones.Entities;
using Zdr.RiskZones.Enums;
using Zdr.RiskZones.HelperEntities;
using Zdr.Users;

namespace Zdr.RiskZones
{
    public class RiskZoneAppService : ApplicationService, IRiskZoneAppService
    {
        private readonly ImageProvider _imageProvider;
        private readonly MapZoneManager _mapZoneManager;
        private readonly LocationManager _locationManager;
        private readonly UserManager _userManager;
        private const string RiskImagesFolder = "/Content/RiskZones/Posts/{0}/";
        public RiskZoneAppService(MapZoneManager mapZoneManager, ImageProvider imageProvider, LocationManager locationManager, UserManager userManager)
        {
            _mapZoneManager = mapZoneManager;
            _imageProvider = imageProvider;
            _locationManager = locationManager;
            _userManager = userManager;
        }
        [AbpAuthorize()]
        public async Task<int> CreateZone(RiskZoneInputDto input)
        {
            input.Images = new List<HttpPostedFileBase>();
            for (var i = 0; i < input.RequestFiles.Count; i++)
            {
                var file = input.RequestFiles[i];
                input.Images.Add(file);
            }
            if (!AbpSession.UserId.HasValue) throw new UserFriendlyException("No autorizado");
            var city = await ResolveLocation(input);

            var category = _mapZoneManager.GetCategory(1);

            var mapCreationRequest = new MapZoneEntityCreationObject()
            {
                City = city,
                Content = input.Content,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                User = await _userManager.GetUserByIdAsync(AbpSession.UserId.Value),
                Category = category,
                ZoneType = GetZoneType(input)
            };
            var zone = MapZone.CreateZone(mapCreationRequest);
            var id = await _mapZoneManager.AddZone(zone);
            if (input.Images.Any())
            {
                await SaveGallery(input.Images, zone);
            }

            return id;

        }

        private int GetZoneType(RiskZoneInputDto input)
        {
            if (string.IsNullOrEmpty(input.Content))
            {
                return (int)ZoneType.Fast;
            }
            if (input.Images.Any())
            {
                return (int)ZoneType.WithContentImage;
            }
            return (int)ZoneType.WithContent;
        }

        private async Task SaveGallery(List<HttpPostedFileBase> images, MapZone zone)
        {
            var fixedFolder = string.Format(RiskImagesFolder, zone.Id);
            foreach (var httpPostedFileBase in images)
            {
                var small = _imageProvider.SaveImage(75, 75, httpPostedFileBase, fixedFolder);
                var normal = _imageProvider.SaveImage(0, 0, httpPostedFileBase, fixedFolder);
                await _mapZoneManager.AddImageToGallery(MapZoneGallery.CreateMapZoneGallery(normal, zone, small));
            }
        }

        /// <summary>
        /// Creates a country -> state -> city if necessary
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private async Task<City> ResolveLocation(RiskZoneInputDto input)
        {
            var country = Country.CreateCountry(input.CountryLongName, input.Country);
            var countryResult = await _locationManager.CreateCountry(country);
            var state = State.CreateState(input.StateLongName, input.State, countryResult);
            var stateResult = await _locationManager.CreateState(state);
            var city = City.CreateCity(input.CityLongName, input.City, stateResult);
            var cityResult = await _locationManager.CreateCity(city);
            return cityResult;
        }
        public RiskZoneInputDto GetZoneForEdit(int id)
        {
            throw new System.NotImplementedException();
        }

        public RiskZonesOutput GetRiskZonesByCity(string cityCode)
        {
            var rizkZones = _mapZoneManager.GetZones(cityCode);

            var positions = new List<RiskZonePositionDto>();
            foreach (var rizkZone in rizkZones)
            {
                var decimalLat = rizkZone.Latitude;
                var decimalLong = rizkZone.Longitude;
                positions.Add(new RiskZonePositionDto()
                {
                    Icon = "",
                    Id = rizkZone.Id,
                    Latitude = decimalLat,
                    Longitude = decimalLong
                });
            }
            return new RiskZonesOutput()
            {
                Positions = positions
            };
        }

        public RiskZonesOutput GetRiskZonesWithDistance(RiskZoneByDistanceParams input)
        {
            var data = input;
            var distance = Distance.HaversineDistance(input.Center, input.Bounds.Northeast, Distance.DistanceUnit.Km);

            return new RiskZonesOutput();
        }
    }
}
