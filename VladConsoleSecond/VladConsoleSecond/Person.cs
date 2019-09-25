using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladConsoleSecond
{
    public class Person
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public Color FavouriteColor { get; set; }

        public Person (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    public enum Color
    {
        Unknow,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        White,
        Black
    }
}
