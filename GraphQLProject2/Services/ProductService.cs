using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using System.Collections.Generic;

namespace GraphQLProject.Services
{
    public class ProductService : IProduct
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 0, Name = "Coffee", Price = 3.99 },
            new Product { Id = 1, Name = "Tee", Price = 2.99 },
            new Product { Id = 2, Name = "Juice", Price = 4.99 },
            new Product { Id = 3, Name = "Water", Price = 1.99 },

        };

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public void DeleteProduct(int id)
        {
            products.RemoveAt(id);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            products[id] = product; 
            return product;
        }
    }
}
