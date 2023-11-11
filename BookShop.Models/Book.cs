using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId {  get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
