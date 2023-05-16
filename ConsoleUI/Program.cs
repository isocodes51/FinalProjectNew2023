using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entitites.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{   //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            // CategoryTest();
            EklemeTest();

        }

        private static void EklemeTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            Product product = new Product
            {
                //ProductId = 10000,
                CategoryId = 1,
                ProductName = "Bilgisayar",
                UnitsInStock = 1,
                UnitPrice = 15000

            };

            productManager.Add(product);
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+" "+product.CategoyName);
            }
        }

        
       

    }
}
