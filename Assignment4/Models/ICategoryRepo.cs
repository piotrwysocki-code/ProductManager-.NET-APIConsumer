using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    public interface ICategoryRepo
    {
        public IEnumerable<Category> IECategory { get; }
        void AddCategory(Category c);
    }
}
