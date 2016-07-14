using EntityFramework.DynamicFilters;
using Zdr.EntityFramework;

namespace Zdr.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ZdrDbContext _context;

        public InitialHostDbBuilder(ZdrDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultStatesAndCities(_context).Create();
        }
    }
}
