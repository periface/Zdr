using System.Collections.Generic;
using System.Linq;
using Zdr.EntityFramework;
using Zdr.Locations.Entities;

namespace Zdr.Migrations.SeedData
{
    public class DefaultStatesAndCities
    {
        private readonly ZdrDbContext _context;

        public DefaultStatesAndCities(ZdrDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateFirstCities();
        }

        private void CreateFirstCities()
        {
            var country = _context.Cities.FirstOrDefault();
            if (country == null)
            {
                _context.Countries.Add(new Country()
                {
                    CountryCode = "MX",
                    CountryFullName = "México",
                    States = new List<State>()
                    {
                        new State()
                        {
                            StateCode = "Tam",
                            StateFullName = "Tamaulipas",
                            Cities = new List<City>()
                            {
                                new City()
                                {
                                    CityCode = "CV",
                                    CityFullName = "Ciudad Victoria"
                                }
                            }
                        }
                    }
                });
            }
        }
    }
}
