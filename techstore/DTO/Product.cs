using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techstore.DTO
{
    public class Product
    {
        public string name { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
        public string des { get; set; }
        public bool available { get; set; }
    }
}
