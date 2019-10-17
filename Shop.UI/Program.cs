/*
 * 1. Регистрация и вход (смс-код / email код) - сделать до 11 октября
 * 2. История покупок
 * 3. Категории и товары (картинка в файловой системе)
 * 4. Покупка (корзина), оплата и доставка (PayPal/Qiwi/etc)
 * 5. Комментарии и рейтинги
 * 6. Поиск (пагинация)
 * 
 * Кто сделает 3 версии (Подключённый, автономный и EF) получит автомат на экзамене.
 */

using Microsoft.Extensions.Configuration;
using Shop.DataAccess;
using Shop.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            IConfigurationRoot configurationRoot = builder.Build();

            string providerName = configurationRoot.GetSection("AppConfig")
                                 .GetChildren()
                                 .Single()
                                 .Value;

            string connectionString = configurationRoot.GetConnectionString("DebugConnectionString");
            var categories = new List<Category>() {
             new Category
            {
                Name = "Бытовая техника",
                ImagePath = "C:/data"
            }
        }
            var items = new List<Item>() {
            new Item
            {
                 Name = "Стиральная машина",
                ImagePath = "C:/data",
                Price = 100000,
                Description = "cool",
                CategoryId = category.Id
            }
            }
            using (var context = new ShopContext(connectionString))
            {
                context.Categories.Add(category);
                var result1 = context.Categories.ToList();   //получает все результаты из бд
                context.Categories.Remove(category);
                //context.Remove(category);    
                context.Items.Add(item);
                var result2 = context.Items.ToList();
              //  context.Items.Remove(item);
                context.SaveChanges();  //автомотически сохраняет все изменения
            }
            }
        }
    }
