using Microsoft.EntityFrameworkCore;
using SharedTravel.Models;

namespace SharedTravel.Data
{
    public class AppDbContext : DbContext
    {
        //  EF Core сам обходит классы по связям.
        // Trip ссылается на City, Participant, Expense и Settlement, а Expense на ExpenseShare и Category, поэтому все они станут таблицами.
        public DbSet<Trip> Trips { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseShare> ExpenseShares { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //  Используй базу sharedtravel.db3 по пути path
            var path = Path.Combine(FileSystem.AppDataDirectory, "sharedtravel.db3");
            options.UseSqlite($"Filename={path}");
        }
    }
}
