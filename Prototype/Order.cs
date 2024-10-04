using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{
    public class Order : IClonable<Order>
    {
        public List<Product> Products { get; set; }
        public int PriceOfDelivery { get; set; }
        public List<Discount> Discounts { get; set; }
        public string PaymentMethod {  get; set; }
        public int TotalPrice {  get; set; }
        public int TotalPriceWithDiscount { get; set; }
        public Order() { }
        public Order(int priceOfDelivery, string paymentMethod)
        {
            Products = new List<Product>();
            PriceOfDelivery = priceOfDelivery;
            Discounts = new List<Discount>();
            PaymentMethod = paymentMethod;
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
            TotalPrice += product.Price;
            UpdateTotalPriceWithDiscount();
        }
        public void AddDiscount(Discount discount)
        {
            Discounts.Add(discount);
            UpdateTotalPriceWithDiscount();
        }
        private void UpdateTotalPriceWithDiscount()
        {
            TotalPriceWithDiscount = TotalPrice;
            foreach (Discount discount in Discounts)
            {
                TotalPriceWithDiscount = TotalPriceWithDiscount * (100 - discount.Percentage) / 100;
            }
        }
        public Order Clone()
        {
            Order clone = new Order(PriceOfDelivery, PaymentMethod);
            foreach (Product product in Products)
            {
                clone.Products.Add(product.Clone());
            }
            foreach (Discount discount in Discounts)
            {
                clone.Discounts.Add(discount.Clone());
            }
            clone.TotalPrice = TotalPrice;
            clone.TotalPriceWithDiscount = TotalPriceWithDiscount;
            return clone;
        }
    }
}
