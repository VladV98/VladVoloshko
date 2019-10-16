using ShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabase
{
	class Program
	{
		static void Main(string[] args)
        {
            List<Food> groceries = new List<Food>
            {
                new Food("apple", 1.7),
                new Food("bread", 1.2),
                new Food("cheese", 2)
            };

            ShoppingCart newCart = new ShoppingCart();

            ChooseFood(groceries, newCart); // Select rows - Edit - Refactor - Encapsulate Field
            while (Console.ReadLine() == "Yes")
            {
                ChooseFood(groceries, newCart);
            }

            //foreach (var food in groceries)
            //{
            //    newCart.Items.Add(food);
            //}

            using (var db = new ShopDbContext())
            {
                IQueryable <ShoppingCart> cartWithZeroSum = db.ShoppingCarts.Where(x => x.Sum == 0);
                foreach(var cart in cartWithZeroSum)
                {
                    db.ShoppingCarts.Remove(cart);
                }
                db.SaveChanges();

                db.ShoppingCarts.Add(newCart);
                db.SaveChanges();

                var carts = db.ShoppingCarts.Include("Items").OrderByDescending(x => x.DateCreated).ToList();
                //Console.WriteLine($"Last order was {carts}");
                foreach (var cart in carts)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
                    foreach (var food in cart.Items)
                    {
                        Console.WriteLine($"Last order was {food.Name}");
                        Console.WriteLine($"Name: {food.Name}  Price: {food.Price}");
                    }
                    Console.WriteLine($"Total: {cart.Sum}");
                }
            }

        }

        private static void ChooseFood(List<Food> groceries, ShoppingCart newCart)
        {
            Console.WriteLine("What do you want to buy?");
            string foodName = Console.ReadLine();
            Food chosenFood = groceries.FirstOrDefault(x => x.Name == foodName);
            newCart.AddToCart(chosenFood);
            Console.WriteLine("Anything else? Yes/No");
        }
    }
}
