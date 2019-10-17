using Microsoft.EntityFrameworkCore;

namespace TourApi.Models
{
    public class TourContext : DbContext
    {
        public TourContext(DbContextOptions<TourContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
    }
}