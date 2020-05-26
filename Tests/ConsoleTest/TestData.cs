using ConsoleTest.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class TestData
    {
        public static IEnumerable<StructureBdCategorys> Categorys { get; } = new[]
        {
            new StructureBdCategorys { id = 1, catName = "Беговые дорожки", },
            new StructureBdCategorys { id = 2, catName = "Велотренажеры"},
            new StructureBdCategorys { id = 3, catName = "Эллиптические",  },
            new StructureBdCategorys { id = 4, catName = "Гребные", },
            new StructureBdCategorys { id = 5, catName = "Степперы", },
            new StructureBdCategorys { id = 6, catName = "Силовые центры", },
            new StructureBdCategorys { id = 7, catName = "Аксессуары для тренажеров", },
            new StructureBdCategorys { id = 8, catName = "Детские спортивные комплексы", },
        };


        public static IEnumerable<StructureBdProducts> Products { get; } = new[]
        {
            #region Беговые дорожки
            new StructureBdProducts { id = 1, CategorysId =1, name = "Беговая дорожка Kettler TRACK S4", description = "Беговая дорожа KETTLER S4 нового поколения позволяет поддерживать отличную форму в любое время года.", price=64_999 },
            new StructureBdProducts { id= 2, CategorysId =1, name = "Беговая дорожка NordicTrack S25", description = "практичная компактная беговая дорожка для ваших домашних тренировок. Оснащена мощным двигателем и системой амортизации.В вашем распоряжении система быстрой настройки скорости и угла наклона бегового полотна в одно касание, Bluetooth модуль для коммуникации с другими устройствами.", price=69_999 },
            new StructureBdProducts { id= 3, CategorysId =1, name = "Беговая дорожка Kettler TRACK S4", description = "позволяет поддерживать отличную форму в любое время года.", price=64_999 },
            new StructureBdProducts { id= 4, CategorysId =1, name = "Беговая дорожка Kettler TRACK S8", description = "позволяет поддерживать отличную форму в любое время года.", price=119_999 },
            new StructureBdProducts { id= 5, CategorysId =1, name = "Беговая дорожка электрическая LifeSpan TR1200iC", description = "позволяет поддерживать отличную форму в любое время года.", price=79_999 },
            new StructureBdProducts { id= 6, CategorysId =1, name = "Беговая дорожка NordicTrack Incline Trainer X7i", description = "позволяет поддерживать отличную форму в любое время года.", price=119_999 },
            new StructureBdProducts { id= 7, CategorysId =1, name = "Беговая дорожка Torneo Maestra", description = "позволяет поддерживать отличную форму в любое время года.", price=41_999 },
            new StructureBdProducts { id= 8, CategorysId =1, name = "Беговая дорожка Kettler TRACK S10", description = "позволяет поддерживать отличную форму в любое время года.", price=129_999 },
            new StructureBdProducts { id= 9, CategorysId =1, name = "Беговая дорожка Lifespan TR5500IC", description = "позволяет поддерживать отличную форму в любое время года.", price=159_999 },
            new StructureBdProducts { id= 10, CategorysId =1, name = "Беговая дорожка Kettler Track 3", description = "позволяет поддерживать отличную форму в любое время года.", price=71_999 },
            new StructureBdProducts { id= 11, CategorysId =1, name = "Беговая дорожка Lifespan TR3000IC", description = "позволяет поддерживать отличную форму в любое время года.", price=89_999 },
            new StructureBdProducts { id= 12, CategorysId =1, name = "Беговая дорожка NordicTrack Commercial 2450", description = "позволяет поддерживать отличную форму в любое время года.", price=119_999 },
            new StructureBdProducts { id= 13, CategorysId =1, name = "Беговая дорожка электрическая NordicTrack S 40", description = "позволяет поддерживать отличную форму в любое время года.", price=145_999 },
            new StructureBdProducts { id= 14, CategorysId =1, name = "Беговая дорожка Lifespan TR4000IC", description = "позволяет поддерживать отличную форму в любое время года.", price=99_999 },
            new StructureBdProducts { id= 15, CategorysId =1, name = "Беговая дорожка Kettler Track R9", description = "позволяет поддерживать отличную форму в любое время года.", price=139_999 },
            new StructureBdProducts { id= 16, CategorysId =1, name = "Беговая дорожка Pro-Form Performance 400i", description = "позволяет поддерживать отличную форму в любое время года.", price=99_999 },
            new StructureBdProducts { id= 17, CategorysId =1, name = "Беговая дорожка Kettler TRACK S10", description = "позволяет поддерживать отличную форму в любое время года.", price=69_999 },
            new StructureBdProducts { id= 18, CategorysId =1, name = "Беговая дорожка PRO-FORM 705 CST", description = "позволяет поддерживать отличную форму в любое время года.", price=129_999 },
            new StructureBdProducts { id= 19, CategorysId =1, name = "Беговая дорожка Kettler Track 5", description = "позволяет поддерживать отличную форму в любое время года.", price=89_999 },
            new StructureBdProducts { id= 20, CategorysId =1, name = "Беговая дорожка Torneo Smarta", description = "позволяет поддерживать отличную форму в любое время года.", price=74_999 },
            #endregion

            #region Велотренажоры
            new StructureBdProducts { id= 21, CategorysId =2, name = "Велотренажер магнитный Torneo Vita", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=14_999 },
            new StructureBdProducts { id= 22, CategorysId =2, name = "Мини-велотренажер Torneo Duo", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=2_999 },
            new StructureBdProducts { id= 23, CategorysId =2, name = "Велотренажер магнитный Torneo Nova", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=7_999 },
            new StructureBdProducts { id= 24, CategorysId =2, name = "Велотренажер магнитный Torneo Jazz", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=19_999 },
            new StructureBdProducts { id= 25, CategorysId =2, name = "Велотренажер магнитный Kettler Axos Cycle M", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=19_999 },
            new StructureBdProducts { id= 26, CategorysId =2, name = "Мини-велотренажер Torneo Smart Bike", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=3_999 },
            new StructureBdProducts { id= 27, CategorysId =2, name = "Велотренажер Kettler Cycle M", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=19_999 },
            new StructureBdProducts { id= 28, CategorysId =2, name = "Складной велотренажер Torneo TransformMe", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=10_999 },
            new StructureBdProducts { id= 29, CategorysId =2, name = "Велотренажер магнитный Kettler Giro C1 Classic", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=24_999 },
            new StructureBdProducts { id= 30, CategorysId =2, name = "Велотренажер магнитный Pro-Form 210 CSX", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=21_999 },
            new StructureBdProducts { id= 31, CategorysId =2, name = "Велотренажер магнитный NordicTrack GX 2.7 U", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=29_999 },
            new StructureBdProducts { id= 32, CategorysId =2, name = "Велотренажер магнитный Lifespan C15W", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=24_999 },
            new StructureBdProducts { id= 33, CategorysId =2, name = "Велотренажер магнитный NordicTrack GX 4.6 Pro", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=74_999 },
            new StructureBdProducts { id= 34, CategorysId =2, name = "Велотренажер Kettler Giro R3", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=54_999 },
            new StructureBdProducts { id= 35, CategorysId =2, name = "Велотренажер Pro-Form магнитный 225 CSX", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=24_999 },
            new StructureBdProducts { id= 36, CategorysId =2, name = "Велотренажер Torneo Favourit Ergo", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=34_999 },
            new StructureBdProducts { id= 37, CategorysId =2, name = "Велотренажер Torneo Favourit Ergo", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=34_999 },
            new StructureBdProducts { id= 38, CategorysId =2, name = "Велотренажер магнитный Torneo Siesta", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=27_999 },
            new StructureBdProducts { id= 39, CategorysId =2, name = "Велотренажер магнитный C5I", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=69_999 },
            new StructureBdProducts { id= 40, CategorysId =2, name = "Велотренажер магнитный Lifespan R5I", description = "Простой и надежный велотренажер отлично подходит для кардиотренировок. Занятия укрепляют мышцы ног и пресса и повышают аэробную выносливость.", price=89_999 },
            #endregion

            #region Элептика
            new StructureBdProducts { id= 41, CategorysId =3, name = "Тренажер эллиптический Lifespan EL15W", description = "отличный выбор для домашних кардиотренировок.", price=27_999 },
            new StructureBdProducts { id= 42, CategorysId =3, name = "Тренажер эллиптический Lifespan E2I", description = "отличный выбор для домашних кардиотренировок.", price=99_999 },
            new StructureBdProducts { id= 43, CategorysId =3, name = "Тренажер эллиптический NordicTrack Commercial 12.9", description = "отличный выбор для домашних кардиотренировок.", price=99_999 },
            new StructureBdProducts { id= 44, CategorysId =3, name = "Тренажер эллиптический Pro-Form Cardio Hiit", description = "отличный выбор для домашних кардиотренировок.", price=79_999 },
            new StructureBdProducts { id= 45, CategorysId =3, name = "Тренажер эллиптический Lifespan E3I", description = "отличный выбор для домашних кардиотренировок.", price=119_999 },
            new StructureBdProducts { id= 46, CategorysId =3, name = "Эллиптический эргометр Kettler Unix 10EXT", description = "отличный выбор для домашних кардиотренировок.", price=111_999 },
            new StructureBdProducts { id= 47, CategorysId =3, name = "Эллиптический тренажер Torneo Visto", description = "отличный выбор для домашних кардиотренировок.", price=139_999 },
            new StructureBdProducts { id= 48, CategorysId =3, name = "Эллиптический тренажер Torneo Vento", description = "отличный выбор для домашних кардиотренировок.", price=11_999 },
            new StructureBdProducts { id= 49, CategorysId =3, name = "Тренажер эллиптический Torneo Festa", description = "отличный выбор для домашних кардиотренировок.", price=11_999 },
            new StructureBdProducts { id= 50, CategorysId =3, name = "Эллиптический тренажер Torneo Stella", description = "отличный выбор для домашних кардиотренировок.", price=16_999 },
            new StructureBdProducts { id= 51, CategorysId =3, name = "Тренажер эллиптический Torneo F-Drive", description = "отличный выбор для домашних кардиотренировок.", price=25_999 },
            new StructureBdProducts { id= 52, CategorysId =3, name = "Эллиптический тренажер Kettler Cross M", description = "отличный выбор для домашних кардиотренировок.", price=26_999 },
            new StructureBdProducts { id= 53, CategorysId =3, name = "Тренажер эллиптический складной Torneo Transform", description = "отличный выбор для домашних кардиотренировок.", price=29_999 },
            new StructureBdProducts { id= 54, CategorysId =3, name = "Эллиптический тренажер Kettler Rivo 2", description = "отличный выбор для домашних кардиотренировок.", price=33_999 },
            new StructureBdProducts { id= 55, CategorysId =3, name = "Тренажер эллиптический PRO-FORM 325 CSE", description = "отличный выбор для домашних кардиотренировок.", price=34_999 },
            new StructureBdProducts { id= 56, CategorysId =3, name = "Эргометр эллиптический Torneo Premium Ergo", description = "отличный выбор для домашних кардиотренировок.", price=34_999 },
            new StructureBdProducts { id= 57, CategorysId =3, name = "Тренажер эллиптический Pro-Form Hybrid Trainer", description = "отличный выбор для домашних кардиотренировок.", price=37_999 },
            new StructureBdProducts { id= 58, CategorysId =3, name = "Эллиптический тренажер Kettler Rivo 4", description = "отличный выбор для домашних кардиотренировок.", price=39_999 },
            new StructureBdProducts { id= 59, CategorysId =3, name = "Эллиптический тренажер Kettler Skylon 2", description = "отличный выбор для домашних кардиотренировок.", price=39_999 },
            new StructureBdProducts { id= 60, CategorysId =3, name = "Тренажер эллиптический NordicTrack SE3i", description = "отличный выбор для домашних кардиотренировок.", price=49_999 },

            #endregion

            #region Гребной
            new StructureBdProducts { id= 61, CategorysId =4, name = "Тренажер гребной Kettler Сoach H2O", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=59999 },
            new StructureBdProducts { id= 62, CategorysId =4, name = "Тренажер гребной Kettler Skif", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=33999 },
            new StructureBdProducts { id= 63, CategorysId =4, name = "Гребной тренажер NordicTrack RX 800", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=39999 },
            new StructureBdProducts { id= 64, CategorysId =4, name = "Тренажер гребной Kettler Coach 2", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=59999 },
            new StructureBdProducts { id= 65, CategorysId =4, name = "Гребной тренажер Kettler Kadett", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=31999 },
            new StructureBdProducts { id= 66, CategorysId =4, name = "Тренажер гребной COACH 2", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=39999 },
            new StructureBdProducts { id= 67, CategorysId =4, name = "Гребной тренажер Kettler Favorit", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=59999 },
            new StructureBdProducts { id= 68, CategorysId =4, name = "Гребной тренажер Torneo Octopus", description = "Модель станет отличным выбором для домашних кардиотренировок и поможет укрепить мышцы ног, пресса, спины, груди, рук и плеч. Система регулировки сопротивления позволяет подобрать уровень нагрузки индивидуально.", price=23999 },

	            #endregion

        };




        /*
        public static List<Employee> Employees { get; } = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                SurName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Age = 39
            },
            new Employee
            {
                Id = 2,
                SurName = "Петров",
                FirstName = "Пётр",
                Patronymic = "Петрович",
                Age = 18
            },
            new Employee
            {
                Id = 3,
                SurName = "Сидоров",
                FirstName = "Сидор",
                Patronymic = "Сидорович",
                Age = 27
            },
        };

        public static IEnumerable<Section> Sections { get; } = new[]
       {
              new Section { Id = 1, Name = "Спорт", Order = 0 },
              new Section { Id = 2, Name = "Nike", Order = 0, ParentId = 1 },
              new Section { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 },
              new Section { Id = 4, Name = "Adidas", Order = 2, ParentId = 1 },
              new Section { Id = 5, Name = "Puma", Order = 3, ParentId = 1 },
              new Section { Id = 6, Name = "ASICS", Order = 4, ParentId = 1 },
              new Section { Id = 7, Name = "Для мужчин", Order = 1 },
              new Section { Id = 8, Name = "Fendi", Order = 0, ParentId = 7 },
              new Section { Id = 9, Name = "Guess", Order = 1, ParentId = 7 },
              new Section { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
              new Section { Id = 11, Name = "Диор", Order = 3, ParentId = 7 },
              new Section { Id = 12, Name = "Версачи", Order = 4, ParentId = 7 },
              new Section { Id = 13, Name = "Армани", Order = 5, ParentId = 7 },
              new Section { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
              new Section { Id = 15, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
              new Section { Id = 16, Name = "Шанель", Order = 8, ParentId = 7 },
              new Section { Id = 17, Name = "Гуччи", Order = 9, ParentId = 7 },
              new Section { Id = 18, Name = "Для женщин", Order = 2 },
              new Section { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
              new Section { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
              new Section { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
              new Section { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
              new Section { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
              new Section { Id = 24, Name = "Для детей", Order = 3 },
              new Section { Id = 25, Name = "Мода", Order = 4 },
              new Section { Id = 26, Name = "Для дома", Order = 5 },
              new Section { Id = 27, Name = "Интерьер", Order = 6 },
              new Section { Id = 28, Name = "Одежда", Order = 7 },
              new Section { Id = 29, Name = "Сумки", Order = 8 },
              new Section { Id = 30, Name = "Обувь", Order = 9 },
        };

        public static IEnumerable<Product> Products { get; } = new[]
        {
            new Product { Id = 1, Name = "Белое платье", Price = 1025, ImageUrl = "product1.jpg", Order = 0, SectionId = 2, BrandId = 1 },
            new Product { Id = 2, Name = "Розовое платье", Price = 1025, ImageUrl = "product2.jpg", Order = 1, SectionId = 2, BrandId = 1 },
            new Product { Id = 3, Name = "Красное платье", Price = 1025, ImageUrl = "product3.jpg", Order = 2, SectionId = 2, BrandId = 1 },
            new Product { Id = 4, Name = "Джинсы", Price = 1025, ImageUrl = "product4.jpg", Order = 3, SectionId = 2, BrandId = 1 },
            new Product { Id = 5, Name = "Лёгкая майка", Price = 1025, ImageUrl = "product5.jpg", Order = 4, SectionId = 2, BrandId = 2 },
            new Product { Id = 6, Name = "Лёгкое голубое поло", Price = 1025, ImageUrl = "product6.jpg", Order = 5, SectionId = 2, BrandId = 1 },
            new Product { Id = 7, Name = "Платье белое", Price = 1025, ImageUrl = "product7.jpg", Order = 6, SectionId = 2, BrandId = 1 },
            new Product { Id = 8, Name = "Костюм кролика", Price = 1025, ImageUrl = "product8.jpg", Order = 7, SectionId = 25, BrandId = 1 },
            new Product { Id = 9, Name = "Красное китайское платье", Price = 1025, ImageUrl = "product9.jpg", Order = 8, SectionId = 25, BrandId = 1 },
            new Product { Id = 10, Name = "Женские джинсы", Price = 1025, ImageUrl = "product10.jpg", Order = 9, SectionId = 25, BrandId = 3 },
            new Product { Id = 11, Name = "Джинсы женские", Price = 1025, ImageUrl = "product11.jpg", Order = 10, SectionId = 25, BrandId = 3 },
            new Product { Id = 12, Name = "Летний костюм", Price = 1025, ImageUrl = "product12.jpg", Order = 11, SectionId = 25, BrandId = 3 },
        };

    */
    }
}
