using System.Collections.Generic;


namespace Assignment4.Models
{
    public class CategoryRepo : ICategoryRepo
    {
        private Dictionary<string, Category> _categories = new Dictionary<string, Category>();

        public CategoryRepo()
        {

        }

        public void AddCategory(Category p)
        {
            if (!_categories.ContainsKey(p.CategoryId.ToString()))
            {
                _categories.Add(p.CategoryId.ToString(), p);
            }
        }


        public static CategoryRepo categoryRepo { get; } = new CategoryRepo();

        public IEnumerable<Category> IECategory => _categories.Values;
    }
}
