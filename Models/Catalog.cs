using ProductManagement.Models;
using System.Collections.Generic;

namespace ProductManagement.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
