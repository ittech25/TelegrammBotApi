using Microsoft.EntityFrameworkCore;
using ConsoleTest.SQL;
namespace ConsoleTest.SQL
{
    public class ApplicationContext : DbContext
    {
        /// <summary>Указываем структуру таблица из БД </summary>
        public DbSet<StructureBd> product { get; set; }

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
