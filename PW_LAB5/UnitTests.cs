using Assignment4.Models;
using Assignment4.Controllers;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace PW_LAB5.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestForProductNameProperty()
        {
            //Arrange
            Product p = new Product { ProductName = "Nails" };
            //Act
            p.ProductName = "Screw Driver";
            //Asertion
            Assert.Equal("Screw Driver", p.ProductName);
        }

        [Fact]
        public void TestForProductPriceProperty()
        {
            Product p = new Product { Price = 22.32 };
            p.Price = 55.32;
            Assert.Equal(55.32, p.Price);
        }

        //Checking the controller test
        [Fact]
        public async Task TestGetAllProducts()
        {
            //Arrangements
            HomeController controller = new HomeController();
            controller.repo = new FakeRepository();

            //Act
            var products = ((controller.Index() as Task<IActionResult>).Result as ViewResult)?.ViewData.Model as IEnumerable<Product>;


            //Assert
            Assert.Equal(controller.repo.IEProduct, products,
                            ComparingClass.GetComparer<Product>((p1, p2) => p1.ProductName == p2.ProductName && p1.Price == p2.Price));

        }


        [Fact]
        public async Task TestAddProduct()
        {
            //Arrangements
            HomeController controller = new HomeController();
            controller.repo = new FakeRepository();
            Product p = new Product() { ProductId = 112, ProductName = "test product", Price = 11.11, CategoryId = 2 };

            //Act
            var model = ((controller.AddProduct(p) as Task<IActionResult>).Result as ViewResult)?.ViewData.Model as Product;
            var products = ((controller.Index() as Task<IActionResult>).Result as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(controller.repo.IEProduct, products,
                            ComparingClass.GetComparer<Product>((p1, p2) => p1.ProductName == p2.ProductName && p1.Price == p2.Price));

        }

        [Fact]
        public async Task TestGetProduct()
        {
            //Arrangements
            HomeController controller = new HomeController();
            controller.repo = new FakeRepository();

            //Act
            var model = ((controller.GetProduct(112) as Task<IActionResult>).Result as ViewResult)?.ViewData.Model as Product;
            var products = ((controller.Index() as Task<IActionResult>).Result as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(controller.repo.IEProduct, products,
                            ComparingClass.GetComparer<Product>((p1, p2) => p1.ProductName == p2.ProductName && p1.Price == p2.Price));

        }

        [Fact]
        public async Task TestDeleteProduct()
        {
            //Arrangements
            HomeController controller = new HomeController();
            controller.repo = new FakeRepository();

            //Act
            var model = ((controller.DeleteProduct(112) as Task<IActionResult>).Result as ViewResult)?.ViewData.Model as Product;
            var products = ((controller.Index() as Task<IActionResult>).Result as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(controller.repo.IEProduct, products,
                            ComparingClass.GetComparer<Product>((p1, p2) => p1.ProductName == p2.ProductName && p1.Price == p2.Price));

        }

        public class FakeRepository : IProductRepo
        {
            private Dictionary<string, Product> _products = new Dictionary<string, Product>();

            public void AddProduct(Product p)
            {
                _products.Add(p.ProductName, p);
            }

            public static ProductRepo productRepo { get; } = new ProductRepo();

            public IEnumerable<Product> IEProduct => _products.Values;
        }
    }
}
