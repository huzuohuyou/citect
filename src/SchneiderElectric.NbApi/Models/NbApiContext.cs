using Microsoft.EntityFrameworkCore;

namespace SchneiderElectric.NbApi.Models
{
    public class NbApiContext : DbContext
    {
        //public DbSet<Equipment> Equipments { get; set; }
        //public DbSet<VariableTag> VariableTags { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        //public DbSet<Trend> Trends { get; set; }
        //public DbSet<Accumulator> Accumulators { get; set; }
        //public DbSet<StatisticalProcessControl> StatisticalProcessControls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        }
    }
}
