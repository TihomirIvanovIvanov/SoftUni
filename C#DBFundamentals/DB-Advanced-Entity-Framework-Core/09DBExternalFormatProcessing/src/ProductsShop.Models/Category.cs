using System.Collections.Generic;

namespace ProductsShop.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryProducts = new HashSet<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
