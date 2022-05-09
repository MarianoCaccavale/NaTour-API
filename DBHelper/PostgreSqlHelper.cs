using Microsoft.EntityFrameworkCore;
using NaTour2021_API.Models;

namespace NaTour2021_API.DBHelper
{
    public class PostgreSqlHelper : DbContext
    {
        public PostgreSqlHelper(DbContextOptions<PostgreSqlHelper> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }


        public DbSet<TrackModel> tracks { get; set; }
        public DbSet<PointOfInterestModel> pois { get; set; }
    }
}
