using Microsoft.EntityFrameworkCore;
using ConsoleTest.SQL;
namespace ConsoleTest.SQL
{
    /// <summary>
    /// Класс, подключающийся к БД 
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Указываем структуру таблицы из БД 
        /// (Важно! Наименование должно совпадать с Таблицей из БД) 
        /// </summary>
        public DbSet<StructureBdProducts> products { get; set; }
        public DbSet<StructureBdCategorys> categorys { get; set; }
        public DbSet<StructureBdCart> cart { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //строка подключанея к БД
            optionsBuilder.UseMySql("server = 127.0.0.1; UserId = root; Password = vertrigo; database = telegrammbot;");
        }
    }
}
