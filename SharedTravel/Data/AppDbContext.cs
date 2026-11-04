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
            options.UseSqlite($"Filename={path}")
                //  UseSeeding нужен для первоначального заполнения данными
                .UseSeeding((context, _) =>
                {
                    // Добавляем категории расходов, если их нет в базе SQLite. Это нужно, чтобы при первом запуске приложения пользователь видел категории, а не пустой список.
                    var categories = context.Set<Category>();

                    foreach (var type in Enum.GetValues<CategoryType>())
                    {
                        if(type == CategoryType.Custom) continue; // не добавляем категорию Custom, её создаёт пользователь
                        
                        // Добавляем категорию, если её ещё нет в базе данных
                        if (!categories.Any(c => c.Type == type))
                            categories.Add(new Category { Type = type });
                    }
                    
                    context.SaveChanges();
                });
        }
    }
}
