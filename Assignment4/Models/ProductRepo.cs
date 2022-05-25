using System.Collections.Generic;


namespace Assignment4.Models
{
    public class ProductRepo : IProductRepo
    {
        private Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public ProductRepo()
        {

        }

        public void AddProduct(Product p)
        {
            if (!_products.ContainsKey(p.ProductId.ToString()))
            {
                _products.Add(p.ProductId.ToString(), p);
            }
        }


        public static ProductRepo productRepo { get; } = new ProductRepo();

        public IEnumerable<Product> IEProduct => _products.Values;
    }
}
