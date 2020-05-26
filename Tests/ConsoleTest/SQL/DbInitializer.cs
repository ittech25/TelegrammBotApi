using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.SQL
{
    public class DbInitializer
    {

        private readonly ApplicationContext _db;

        public DbInitializer(ApplicationContext db) => _db = db;

        public void Initialize()
        {
            InitializeAsync().Wait();
            
        }


        public async Task InitializeAsync()
        {
            var db = _db.Database;
            //Проверка  - удалена ли наша БД
            //if (await db.EnsureDeletedAsync().ConfigureAwait(false))
            //{
            //    if (!await db.EnsureCreatedAsync().ConfigureAwait(false))
            //        throw new InvalidOperationException("Не удалось создать БД");
            //}

            //автоматицеская миграция
            await db.MigrateAsync().ConfigureAwait(false);

            //если в нашей БД таблица продукты пустая, то необходимо туда добавить товары
            if (await _db.categorys.AnyAsync()) return;

            //добавляем категории
            using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                //заполняем таблицу Категории
                await _db.categorys.AddRangeAsync(TestData.Categorys).ConfigureAwait(false);

                //ВКЛ - Разрешение на добавление в таблицу
                //await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT categorys ON");
                await _db.SaveChangesAsync().ConfigureAwait(false); //Добавляем данные в БД
                //ВЫКЛ - Разрешение на добавление в таблицу
               // await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT categorys OFF");


                await transaction.CommitAsync().ConfigureAwait(false);
            }

            using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
            {
                //заполняем таблицу Категории
                await _db.products.AddRangeAsync(TestData.Products).ConfigureAwait(false);

                //ВКЛ - Разрешение на добавление в таблицу
                //await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT products ON");
                await _db.SaveChangesAsync().ConfigureAwait(false); //Добавляем данные в БД
                //ВЫКЛ - Разрешение на добавление в таблицу
                //await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT products OFF");


                await transaction.CommitAsync().ConfigureAwait(false);
            }
        }

    }
}
