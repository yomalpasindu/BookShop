using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BooksQueryParameters: QueryParameters
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set;}
        public string Name { get; set; } = string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
    }
}
