using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаем продукты
            Product product1 = new Product(1, "Телефон", "Смартфон с экраном 6.1 дюймов", 430000);
            Product product2 = new Product(2, "Ноутбук", "Ноутбук для работы и учебы", 560000);
            Product product3 = new Product(3, "Чехол", "Чехол для телефона", 560);

            // Создаем скидку
            Discount discount1 = new Discount("Черная пятница", 10);

            // Создаем заказ
            Order order1 = new Order(1200, "Кредитная карта");
            order1.Discounts.Add(discount1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            // Вывод информации о заказе
            Console.WriteLine("Изначальный заказ:");
            Console.WriteLine("Цена заказа: " + order1.TotalPrice);
            Console.WriteLine("Цена заказа со скидкой: " + order1.TotalPriceWithDiscount);
            Console.WriteLine("Метод оплаты: " + order1.PaymentMethod);

            // Клонируем заказ
            Order order2 = order1.Clone();

            // Изменяем заказ
            Product product4 = new Product(4, "Ксерокс", "Обратный принтер", 123000);
            Discount discount2 = new Discount("Постоянному клиенту", 10);
            order2.AddProduct(product4);
            order2.AddDiscount(discount2);

            // Вывод информации о клонированном заказе
            Console.WriteLine("\nКлонированный заказ:");
            Console.WriteLine("Цена заказа: " + order2.TotalPrice);
            Console.WriteLine("Цена заказа со скидкой: " + order2.TotalPriceWithDiscount);
            Console.WriteLine("Метод оплаты: " + order2.PaymentMethod);
        }
    }
}
