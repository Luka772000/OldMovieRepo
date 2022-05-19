using Microsoft.EntityFrameworkCore;

namespace ProjektFinal.Models
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<ProductionHouse> ProductionHouses { get; set; }
    }
}
