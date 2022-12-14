using Microsoft.EntityFrameworkCore;
using Programare_medic.Models;

namespace Programare_medic.Data
{
    public class Programare_medicContext : DbContext
    {
        public Programare_medicContext(DbContextOptions<Programare_medicContext> options)
            : base(options)
        {
        }

        public DbSet<Programare_medic.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Programare_medic.Models.Spital> Spital { get; set; }

        public DbSet<Programare_medic.Models.Sectie> Sectie { get; set; }

        public DbSet<Programare_medic.Models.Medic> Medic { get; set; }
    }
}
