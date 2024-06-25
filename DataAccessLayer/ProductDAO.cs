using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            List<Product> listProducts = new List<Product>();
            try
            {
                using var db = new MyStoreContext();
                listProducts = db.Products.ToList();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listProducts;
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using var db = new MyStoreContext();
                db.Products.Add(p); //Add to product collection 
                db.SaveChanges(); //update database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using var db = new MyStoreContext();
                db.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using var db = new MyStoreContext();
                var p1 = db.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                db.Products.Remove(p1);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Product GetProductById(int id)
        {
            using var db = new MyStoreContext();
            return db.Products.FirstOrDefault(c => c.ProductId.Equals(id));
        }
    }
}
