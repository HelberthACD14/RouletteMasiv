using Microsoft.EntityFrameworkCore;

namespace RouletteMasiv.Models
{
    public class RouletteContext : DbContext
    {
        public RouletteContext(DbContextOptions<RouletteContext> options)
            : base(options)
        {
        }

        public DbSet<RouletteItem> RouletteItems { get; set; }
        public DbSet<RouletteBet> RouletteBets { get; set; }
    }
}