using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        public IProductRepo repo;

        public async Task<IActionResult> Index()
        {
            repo = ProductRepo.productRepo;
            List<Product> products = new List<Product>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/product"))
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiRes);
                }
            }

            foreach (var v in products)
            {
                repo.AddProduct(v);
            }

            return View(products);
        }

        public IActionResult GetProduct() => View();

        [HttpPost]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product prod = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/product/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiRes = await response.Content.ReadAsStringAsync();
                        prod = JsonConvert.DeserializeObject<Product>(apiRes);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }

                }
            }
            return View(prod);
        }

        public IActionResult AddProduct() => View();
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            Console.WriteLine(product.ProductId + "/" + product.ProductName);
            Product p = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                Console.WriteLine(content.ToString());
                Console.WriteLine(product.ProductId + "/" + product.ProductName + "/" + product.Price + "/" + product.CategoryId);
                using (var response = await httpClient.PostAsync("https://localhost:44365/api/product", content))
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Product>(apiRes);
                    Console.WriteLine(apiRes);
                    Console.WriteLine(p.ProductId + "/" + p.ProductName);
                }
            }
            return View(p);
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            Product prod = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/product/" + id))
                {

                    string apiRes = await response.Content.ReadAsStringAsync();
                    prod = JsonConvert.DeserializeObject<Product>(apiRes);
                }

            }

            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Product prod = new Product();
            using (var httpClient = new HttpClient())
            {

                var content = new MultipartFormDataContent();
                content.Add(new StringContent(product.ProductId.ToString()), "ProductID");
                content.Add(new StringContent(product.ProductName), "ProductName");
                content.Add(new StringContent(product.Price.ToString()), "Price");
                content.Add(new StringContent(product.CategoryId.ToString()), "CategoryID");

                using (var response = await httpClient.PutAsync("https://localhost:44365/api/product/", content))
                {

                    string apiRes = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    prod = JsonConvert.DeserializeObject<Product>(apiRes);
                }

            }
            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int productID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44365/api/product/" + productID))
                {

                    string apiRes = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CategoryList(bool error)
        {
            ViewBag.Error = error;
            List<Category> categories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/category"))
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<Category>>(apiRes);
                }
            }
            return View(categories);
        }

        public IActionResult GetCategory() => View();
        [HttpPost]
        public async Task<IActionResult> GetCategory(int id)
        {
            Category category = new Category();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/category/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiRes = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<Category>(apiRes);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }

                }
            }
            return View(category);

        }

        public IActionResult AddCategory() => View();
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            Console.WriteLine(category.CategoryId + "/" + category.CategoryName);
            Category cat = new Category();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
                Console.WriteLine(content.ToString());
                Console.WriteLine(category.CategoryId + "/" + category.CategoryName);
                using (var response = await httpClient.PostAsync("https://localhost:44365/api/category", content))
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    cat = JsonConvert.DeserializeObject<Category>(apiRes);
                    Console.WriteLine(apiRes);
                    Console.WriteLine(cat.CategoryId + "/" + cat.CategoryName);
                }
            }
            return View(cat);
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            Category category = new Category();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/category/" + id))
                {

                    string apiRes = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(apiRes);
                }


            }
            return View(category);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            Category c = new Category();
            using (var httpClient = new HttpClient())
            {

                var content = new MultipartFormDataContent();
                content.Add(new StringContent(category.CategoryId.ToString()), "CategoryID");
                content.Add(new StringContent(category.CategoryName), "CategoryName");

                using (var response = await httpClient.PutAsync("https://localhost:44365/api/category/", content))
                {

                    string apiRes = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    c = JsonConvert.DeserializeObject<Category>(apiRes);
                }

            }
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int categoryID)
        {
            bool error = false;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44365/api/category/" + categoryID))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        error = true;
                    }
                }
            }

            return RedirectToAction("CategoryList", new { error = error });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
