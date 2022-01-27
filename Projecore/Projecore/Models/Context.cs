using Microsoft.EntityFrameworkCore;

namespace Projecore.Models
{
        public class Context:DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-KN1LHAT; database=coreproje;integrated security=true;");
            }
            public DbSet<Firma> Firmas { get; set; }
            public DbSet<Uyeler> Uyelers { get; set; }
        }
    
}
