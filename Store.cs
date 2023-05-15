using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    public class Store
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product FindCheapestProduct()
        {
            if (products.Count == 0)
            {
                return null;
            }

            Product cheapestProduct = products[0];

            foreach (Product product in products)
            {
                if (product.Price < cheapestProduct.Price)
                {
                    cheapestProduct = product;
                }
            }

            return cheapestProduct;
        }
    }
}
