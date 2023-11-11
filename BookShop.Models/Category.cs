using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
