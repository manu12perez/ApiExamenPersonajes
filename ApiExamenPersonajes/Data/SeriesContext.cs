using ApiExamenPersonajes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiExamenPersonajes.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }

}
