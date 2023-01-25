using Microsoft.EntityFrameworkCore;
using SWProvincias_Perez.Models;

namespace SWProvincias_Perez.Data
{
    public class DBPaisFinalContext : DbContext
    {
        public DBPaisFinalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Provincia> provinicias { get; set; }

    }
}
