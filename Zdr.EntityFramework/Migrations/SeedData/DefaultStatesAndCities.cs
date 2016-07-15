using Zdr.EntityFramework;

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
        }

    }
}
