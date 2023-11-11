using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class QueryParameters
    {
        const int maxSize = 15;
        private int size = 10;
        private string sortOrder = "asc";
        public string SortBy { get; set; } = "Id";

        public int Page { get; set; } = 1;
        public int Size { get
            {
                return size;
            } 
            set
            { 
                size=Math.Min(maxSize, value);
            }
        }
        public string SortOrder { get {
                return sortOrder;
            }
            set {
                if (value == "asc" || value == "desc")
                {
                    sortOrder = value;
                }
            }
        }
    }
}
