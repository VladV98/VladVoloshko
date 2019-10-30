using ShopDatabaseAdvanced.Model;
using ShopDatabaseAdvanced.ShopAdvancedDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<Food> groceries = new List<Food>
            {
                new Food("apple", 1.7),
                new Food("bread", 1.2),
                new Food("cheese", 2),
                new Food("milk", 1),
                new Food("icecream", 1.5),
            };
            */
            using (var db = new AdvancedShopDBContext())
            {
                //db.Foods.AddRange(groceries);
                //db.SaveChanges();

                ShoppingCart newCart = new ShoppingCart();
                db.ShoppingCarts.Add(newCart);

                ChooseFood(db, newCart); // Select rows - Edit - Refactor - Encapsulate Field
                while (Console.ReadLine() == "Yes")
                {
                    ChooseFood(db, newCart);
                }
                db.SaveChanges();

                var shoppingCarts = db.ShoppingCarts.Include("Items");
                foreach(var cart in shoppingCarts)
                {
                    Console.WriteLine($"\nShopping cart created on {cart.DateCreated}");
                    foreach(var food in cart.Items)
                    {
                        Console.WriteLine($"{food.Name} Price:{food.Price}");
                    }
                    Console.WriteLine($"Total:{cart.Sum}");
                }
            }
           
        }
        private static void ChooseFood(AdvancedShopDBContext db, ShoppingCart newCart)
        {
            Console.WriteLine("What do you want to buy?");
            string foodName = Console.ReadLine();
            Food chosenFood = db.Foods.FirstOrDefault(x => x.Name == foodName);
            newCart.AddToCart(chosenFood);
            Console.WriteLine("Anything else? Yes/No");
        }
    }
}
