using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class SajtContext : DbContext
    {
        public DbSet<Igra> Igre { get; set; }

        public DbSet<Ocena> Ocene { get; set; }

        public DbSet<Prodavnica> Prodavnice { get; set; }

        public DbSet<Nagrada> Nagrade { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }

        public SajtContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}