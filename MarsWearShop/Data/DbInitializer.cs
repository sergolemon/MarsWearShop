using MarsWearShop.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data
{
    public static class DbInitializer
    {
        public static IEnumerable<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "мужское", Link = "mens" },
            new Category { Id = 2, Name = "женское", Link = "womens" },
            new Category { Id = 3, Name = "аксессуары", Link = "accessories" },
            new Category { Id = 4, Name = "брелки", Link = "keychains", CategoryId = 3 },
            new Category { Id = 5, Name = "шоперы", Link = "shoppers", CategoryId = 3 },
        };

        public static IEnumerable<Size> Sizes = new List<Size> 
        {
            new Size { Id = 1, Name = "NoSize" },
            new Size { Id = 2, Name = "XS" },
            new Size { Id = 3, Name = "S" },
            new Size { Id = 4, Name = "M" },
            new Size { Id = 5, Name = "L" },
            new Size { Id = 6, Name = "XL" },
        };

        public static IEnumerable<ProductSize> ProductSizes = new List<ProductSize> 
        {
            new ProductSize { Id = 1, ProductId = 1, SizeId = 1, Count = 30 },
            new ProductSize { Id = 2, ProductId = 14, SizeId = 1, Count = 20 },

            new ProductSize { Id = 3, ProductId = 2, SizeId = 2, Count = 9 },
            new ProductSize { Id = 4, ProductId = 2, SizeId = 3, Count = 7 },
            new ProductSize { Id = 5, ProductId = 2, SizeId = 4, Count = 12 },

            new ProductSize { Id = 6, ProductId = 3, SizeId = 2, Count = 9 },
            new ProductSize { Id = 7, ProductId = 3, SizeId = 3, Count = 7 },
            new ProductSize { Id = 8, ProductId = 3, SizeId = 4, Count = 12 },

            new ProductSize { Id = 9, ProductId = 4, SizeId = 2, Count = 9 },
            new ProductSize { Id = 10, ProductId = 4, SizeId = 3, Count = 7 },
            new ProductSize { Id = 11, ProductId = 4, SizeId = 4, Count = 12 },

            new ProductSize { Id = 12, ProductId = 5, SizeId = 3, Count = 15 },
            new ProductSize { Id = 13, ProductId = 5, SizeId = 4, Count = 12 },
            new ProductSize { Id = 14, ProductId = 5, SizeId = 5, Count = 10 },

            new ProductSize { Id = 15, ProductId = 6, SizeId = 3, Count = 15 },
            new ProductSize { Id = 16, ProductId = 6, SizeId = 4, Count = 12 },
            new ProductSize { Id = 17, ProductId = 6, SizeId = 5, Count = 10 },

            new ProductSize { Id = 18, ProductId = 7, SizeId = 3, Count = 15 },
            new ProductSize { Id = 19, ProductId = 7, SizeId = 4, Count = 12 },
            new ProductSize { Id = 20, ProductId = 7, SizeId = 5, Count = 10 },

            new ProductSize { Id = 21, ProductId = 8, SizeId = 2, Count = 12 },
            new ProductSize { Id = 22, ProductId = 8, SizeId = 3, Count = 15 },
            new ProductSize { Id = 23, ProductId = 8, SizeId = 4, Count = 17 },

            new ProductSize { Id = 24, ProductId = 9, SizeId = 2, Count = 12 },
            new ProductSize { Id = 25, ProductId = 9, SizeId = 3, Count = 15 },
            new ProductSize { Id = 26, ProductId = 9, SizeId = 4, Count = 17 },

            new ProductSize { Id = 27, ProductId = 10, SizeId = 2, Count = 12 },
            new ProductSize { Id = 28, ProductId = 10, SizeId = 3, Count = 15 },
            new ProductSize { Id = 29, ProductId = 10, SizeId = 4, Count = 17 },

            new ProductSize { Id = 30, ProductId = 11, SizeId = 2, Count = 5 },
            new ProductSize { Id = 31, ProductId = 11, SizeId = 3, Count = 7 },
            new ProductSize { Id = 32, ProductId = 11, SizeId = 4, Count = 9 },
            new ProductSize { Id = 33, ProductId = 11, SizeId = 5, Count = 3 },
            new ProductSize { Id = 34, ProductId = 11, SizeId = 6, Count = 15 },

            new ProductSize { Id = 35, ProductId = 12, SizeId = 2, Count = 5 },
            new ProductSize { Id = 36, ProductId = 12, SizeId = 3, Count = 7 },
            new ProductSize { Id = 37, ProductId = 12, SizeId = 4, Count = 9 },
            new ProductSize { Id = 38, ProductId = 12, SizeId = 5, Count = 3 },
            new ProductSize { Id = 39, ProductId = 12, SizeId = 6, Count = 15 },

            new ProductSize { Id = 40, ProductId = 13, SizeId = 2, Count = 5 },
            new ProductSize { Id = 41, ProductId = 13, SizeId = 3, Count = 7 },
            new ProductSize { Id = 42, ProductId = 13, SizeId = 4, Count = 9 },
            new ProductSize { Id = 43, ProductId = 13, SizeId = 5, Count = 3 },
            new ProductSize { Id = 44, ProductId = 13, SizeId = 6, Count = 15 },
        };

        public static IEnumerable<ProductCategory> ProductCategories = new List<ProductCategory>
        {
            new ProductCategory { Id = 1, ProductId = 1, CategoryId = 3 },
            new ProductCategory { Id = 2, ProductId = 1, CategoryId = 4 },

            new ProductCategory { Id = 3, ProductId = 14, CategoryId = 3 },
            new ProductCategory { Id = 4, ProductId = 14, CategoryId = 5 },

            new ProductCategory { Id = 5, ProductId = 2, CategoryId = 2 },

            new ProductCategory { Id = 7, ProductId = 3, CategoryId = 2 },

            new ProductCategory { Id = 9, ProductId = 4, CategoryId = 2 },

            new ProductCategory { Id = 11, ProductId = 8, CategoryId = 2 },

            new ProductCategory { Id = 13, ProductId = 9, CategoryId = 2 },

            new ProductCategory { Id = 15, ProductId = 10, CategoryId = 2 },

            new ProductCategory { Id = 17, ProductId = 5, CategoryId = 1 },

            new ProductCategory { Id = 21, ProductId = 6, CategoryId = 1 },

            new ProductCategory { Id = 25, ProductId = 7, CategoryId = 1 },

            new ProductCategory { Id = 29, ProductId = 11, CategoryId = 1 },

            new ProductCategory { Id = 33, ProductId = 12, CategoryId = 1 },

            new ProductCategory { Id = 37, ProductId = 13, CategoryId = 1 }
        };

        public static IEnumerable<OrderStatus> OrderStatuses = new List<OrderStatus> 
        {
            new OrderStatus { Id = 1, Name = "новый" },
            new OrderStatus { Id = 2, Name = "подтверждённый" },
            new OrderStatus { Id = 3, Name = "завершённый" }
        };

        public static IEnumerable<Role> Roles = new List<Role> 
        {
            new Role { Id = 1, Name = "Admin" }
        };

        public static IEnumerable<User> Users = new List<User> 
        {
            new User { Id = 1, Login = "admin@gmail.com", Password = "Test", RoleId = 1 },
            new User { Id = 2, Login = "client@gmail.com", Password = "Test" }
        };

        public static IEnumerable<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Брелок «MARS BE LIMITLESS»",
                Description = "Цепляйте куда угодно:\n-Ключи\n-Сумка\n-Штаны\n-Рюкзак\nИдеально дополнит ваш образ!",
                FullPrice = 70,
                DiscountProcent = 20,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 2,
                Name = "Кроп-топ Blue Sky Print",
                Description = "Цвет: голубой\nOversize\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный рисунок",
                FullPrice = 600,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 3,
                Name = "Кроп-топ Pink Crystal Print",
                Description = "Цвет: розовый\nOversize\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный рисунок",
                FullPrice = 600,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 4,
                Name = "Кроп-топ Space Grey Print",
                Description = "Цвет: графит\nOversize\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный рисунок",
                FullPrice = 600,
                DiscountProcent = 10,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 5,
                Name = "Свитшот Blue Sky Print",
                Description = "Цвет: голубой\nOversize & Unisex\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный рисунок",
                FullPrice = 700,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 6,
                Name = "Свитшот Pink Crystal Print",
                Description = "Цвет: розовый\nOversize & Unisex\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный рисунок",
                FullPrice = 700,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 7,
                Name = "Свитшот Space Grey Print",
                Description = "Цвет: графит\nOversize & Unisex\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный рисунок",
                FullPrice = 700,
                DiscountProcent = 10,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 8,
                Name = "Кроп-топ Blue Sky Logo",
                Description = "Цвет: голубой\nOversize\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный вышитый логотип",
                FullPrice = 550,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 9,
                Name = "Кроп-топ Pink Crystal Logo",
                Description = "Цвет: розовый\nOversize\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный вышитый логотип",
                FullPrice = 550,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 10,
                Name = "Кроп-топ Space Grey Logo",
                Description = "Цвет: графит\nOversize\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный вышитый логотип",
                FullPrice = 550,
                DiscountProcent = 10,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 11,
                Name = "Свитшот Blue Sky Logo",
                Description = "Цвет: голубой\nOversize & Unisex\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный вышитый логотип",
                FullPrice = 650,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 12,
                Name = "Свитшот Pink Crystal Logo",
                Description = "Цвет: розовый\nOversize & Unisex\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный вышитый логотип",
                FullPrice = 650,
                DiscountProcent = 0,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 13,
                Name = "Свитшот Space Grey Logo",
                Description = "Цвет: графит\nOversize & Unisex\nЧётко сидит на любой фигуре\nХлопок - 70% / полиестер - 30%\nКачественная ткань\nКачественный вышитый логотип",
                FullPrice = 650,
                DiscountProcent = 10,
                Date = DateTime.Now.Date,
                ShowOnMainPage = true,
                Hide = false
            },
            new Product
            {
                Id = 14,
                Name = "Шоппер LIMITED EDITION",
                Description = "Цвет: чёрный\nзакупайтесь стильно!",
                FullPrice = 100,
                DiscountProcent = 10,
                Date = DateTime.Now.Date,
                ShowOnMainPage = false,
                Hide = false
            }
        };

        public static IEnumerable<Img> Imgs = new List<Img> 
        {
            new Img { Id = 1, ProductId = 1, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (1).jpg") },
            new Img { Id = 2, ProductId = 1, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (2).jpg") },
            new Img { Id = 3, ProductId = 1, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (3).jpg") },

            new Img { Id = 4, ProductId = 2, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (4).jpg") },
            new Img { Id = 5, ProductId = 2, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (5).jpg") },
            new Img { Id = 6, ProductId = 2, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (6).jpg") },

            new Img { Id = 7, ProductId = 3, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (7).jpg") },
            new Img { Id = 8, ProductId = 3, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (8).jpg") },
            new Img { Id = 9, ProductId = 3, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (9).jpg") },

            new Img { Id = 10, ProductId = 4, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (10).jpg") },
            new Img { Id = 11, ProductId = 4, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (11).jpg") },
            new Img { Id = 12, ProductId = 4, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (12).jpg") },

            new Img { Id = 13, ProductId = 5, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (13).jpg") },
            new Img { Id = 14, ProductId = 5, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (14).jpg") },
            new Img { Id = 15, ProductId = 5, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (15).jpg") },

            new Img { Id = 16, ProductId = 6, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (16).jpg") },
            new Img { Id = 17, ProductId = 6, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (17).jpg") },
            new Img { Id = 18, ProductId = 6, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (18).jpg") },

            new Img { Id = 19, ProductId = 7, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (19).jpg") },
            new Img { Id = 20, ProductId = 7, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (20).jpg") },
            new Img { Id = 21, ProductId = 7, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (21).jpg") },

            new Img { Id = 22, ProductId = 8, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (22).jpg") },
            new Img { Id = 23, ProductId = 8, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (23).jpg") },
            new Img { Id = 24, ProductId = 8, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (24).jpg") },

            new Img { Id = 25, ProductId = 9, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (25).jpg") },
            new Img { Id = 26, ProductId = 9, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (26).jpg") },
            new Img { Id = 27, ProductId = 9, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (27).jpg") },

            new Img { Id = 28, ProductId = 10, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (28).jpg") },
            new Img { Id = 29, ProductId = 10, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (29).jpg") },
            new Img { Id = 30, ProductId = 10, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (30).jpg") },

            new Img { Id = 31, ProductId = 11, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (31).jpg") },
            new Img { Id = 32, ProductId = 11, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (32).jpg") },
            new Img { Id = 33, ProductId = 11, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (33).jpg") },

            new Img { Id = 34, ProductId = 12, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (34).jpg") },
            new Img { Id = 35, ProductId = 12, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (35).jpg") },
            new Img { Id = 36, ProductId = 12, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (36).jpg") },

            new Img { Id = 37, ProductId = 13, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (37).jpg") },
            new Img { Id = 38, ProductId = 13, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (38).jpg") },
            new Img { Id = 39, ProductId = 13, TitleImg = false, File = File.ReadAllBytes("wwwroot/img/prod (39).jpg") },

            new Img { Id = 40, ProductId = 14, TitleImg = true, File = File.ReadAllBytes("wwwroot/img/prod (40).jpg") }
        };
    }
}
