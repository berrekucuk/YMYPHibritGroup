using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEvents
{
    internal class ProductRepository
    {
        private static Product product; // Memory de bir kere oluşması için static olarak tanımlıyoruz.

        // Static metotlarda static olan üyelere erişebiliriz.
        //Method static DEĞİLSE hem static üyelere hem normal üyelere erişilebilir.

        static ProductRepository()
        {
            product = new Product() { Id = 1, Name = "Kalem 1", Stock = 20, Barcode = Guid.NewGuid().ToString()};
        }

        internal void UpdateStock(int stock)
        {
            product.Stock = stock;
        }

        internal Product GetProduct()
        {
            return product;
        }
    }
}
