using System;
using System.Collections.Generic;
using System.Text;

namespace Vlad
{
    class DetailedShoppingCart
    {
        List<string> Items { get; set; }
        List<int> price { get; set; }
        List<int> Amounts { get; set; }
        public int Sum { get; set; }

        public DetailedShoppingCart()
        {
            Items = new List<string>();
            Amounts = new List<int>();
            price = new List<int>();
            Sum = 0;
        }

        public void AddToCart(Food food, int amount)
        {

            Items.Clear();
            Amounts.Clear();
            price.Clear();

            Amounts.Add(amount);
            Items.Add(food.Name);
            price.Add(food.Price);


            foreach (object o in Items)
            {
                Console.WriteLine("Item: " + o);
            }

            foreach (object o in price)
            {
                Console.WriteLine("Price: " + o);
            }

            foreach (object o in Amounts)
            {
                Console.WriteLine("Amount: " + o);
                Console.WriteLine();
            }

            Sum = Sum + food.Price * amount;

            //Что лежит в корзине + стоимость + Meetod Calculate Sum
        }
    }
}
