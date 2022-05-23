using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class TravelContext : DbContext
    {
        public DbSet<PacchettoViaggio> PacchettiViaggio{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=DbAgenziaViaggi;Integrated Security=True");
        }
    }
}
