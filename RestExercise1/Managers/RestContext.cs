using Microsoft.EntityFrameworkCore;
using RestExercise8.Models;

namespace RestExercise8.Managers
{
    public class RestContext : DbContext
    {
        public RestContext(DbContextOptions<RestContext> options)
            : base(options) { }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<IPA> IPAs { get; set; }
    }
}
