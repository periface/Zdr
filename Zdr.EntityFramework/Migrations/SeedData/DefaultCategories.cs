using System.Linq;
using Zdr.EntityFramework;
using Zdr.RiskZones.Entities;

namespace Zdr.Migrations.SeedData
{
    public class DefaultCategories
    {
        private readonly ZdrDbContext _context;

        public DefaultCategories(ZdrDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCategories();
        }

        private void CreateCategories()
        {
            var category = _context.MapZoneCategories.FirstOrDefault();
            if (category != null) return;
            _context.MapZoneCategories.Add(MapZoneCategory.CreateCategory("Zona de riesgo", "Zonas de riesgo", ""));
            _context.MapZoneCategories.Add(MapZoneCategory.CreateCategory("Pokemon", "PkMap", ""));
        }
    }
}
