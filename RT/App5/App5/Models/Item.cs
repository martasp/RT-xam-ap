using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app5.Models
{
    public class Item
    {
        public string ImgUrl { get; set; }
        public float Price { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }

        public Item(string imgUrl, float price, string info, string name)
        {
            ImgUrl = imgUrl;
            Price = price;
            Info = info;
            Name = name;
        }

        public Item()
        {
            
        }
    }
}
