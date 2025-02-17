using Microsoft.EntityFrameworkCore;
using TpCrApp.Models;

namespace TpCrApp.Dal
{
    public class TouristPlaceContext:DbContext
    {
        public TouristPlaceContext(DbContextOptions<TouristPlaceContext>options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TouristPlace>().ToTable("TouristPlace");
        }
        public DbSet<TouristPlace> touristPlaces { get; set; }
    }
}
