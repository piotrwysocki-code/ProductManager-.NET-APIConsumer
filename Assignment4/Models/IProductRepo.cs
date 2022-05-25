using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    public interface IProductRepo
    {
        public IEnumerable<Product> IEProduct { get; }
        void AddProduct(Product p);
    }
}
