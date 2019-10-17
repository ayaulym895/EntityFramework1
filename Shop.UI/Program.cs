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

            Category category = new Category
            {
                Name = "Бытовая техника",
                ImagePath = "C:/data"
            };

            using (var context = new ShopContext(connectionString))
            {
                context.Categories.Add(category);
                var result = context.Categories.ToList();
                context.Categories.Remove(category);

                //context.Remove(category);
                context.SaveChanges();  //автомотически сохраняет все изменения
            }
        }
    }
}
