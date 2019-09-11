using System;
using System.Collections.Generic;
using System.Text;

namespace Vlad
{
    class Food
    {
        public string Name {get; set; }

        public int Price { get; set; }

        public Food(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
