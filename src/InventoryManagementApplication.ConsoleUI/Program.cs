using InventoryManagementApplication.Business.Concrete;
using InventoryManagementApplication.DataAccess.Concrete.EntityFramework;
using System;

namespace InventoryManagementApplication.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
        }

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    var categories = categoryManager.GetAll();
        //    foreach (var category in categories)
        //    {
        //        Console.WriteLine(category.CategoryName);
        //    }
        //}

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    var result = productManager.GetProductDetails();

        //    if(result.Success)
        //    {
        //        foreach (var product in result.Data)
        //        {
        //            Console.WriteLine(product.ProductName + "-----" + product.CategoryName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}
    }
}
