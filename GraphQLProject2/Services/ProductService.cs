using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLProject.Services
{
    public class ProductService : IProduct
    {
        //private static List<Product> products = new List<Product>
        //{
        //    new Product { Id = 0, Name = "Coffee", Price = 3.99 },
        //    new Product { Id = 1, Name = "Tee", Price = 2.99 },
        //    new Product { Id = 2, Name = "Juice", Price = 4.99 },
        //    new Product { Id = 3, Name = "Water", Price = 1.99 },

        //};
        
        private GraphQLDbContext _dbContext;
        public ProductService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product;
        }

        public void DeleteProduct(int id)
        {
            var productObj = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(productObj);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productObj = _dbContext.Products.Find(id);
            productObj.Name = product.Name;
            productObj.Price = product.Price;
            _dbContext.SaveChanges();

            return product;
        }
    }
}
