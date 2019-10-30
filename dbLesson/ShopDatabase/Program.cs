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
                foreach (var cart in cartWithZeroSum)
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
                var cartsi = db.ShoppingCarts;
                var cartsWithItems = db.ShoppingCarts.Include("Items");
                var foods = db.Foods;

                //1. Last ctrated cart
                var latest = cartsWithItems.OrderByDescending(cart => cart.DateCreated).ToList().First();
                var latest2 = cartsWithItems.OrderBy(cart => cart.DateCreated).ToList().Last();


                Console.WriteLine();
                Console.WriteLine($"Shopping cart created on {latest.DateCreated}");
                Console.WriteLine($"Shopping cart created on {latest2.DateCreated}");

                //2. Carts with Sum > 5
                var carts5 = carts.Where(x => x.Sum > 5).ToList();
                Console.WriteLine();
                foreach (var cart in carts5)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated} Sum: {cart.Sum}");
                }

                //3.Show only the carts with more than one item in it(with the number of items)
                var cartsMoreThan1 = cartsWithItems.Where(x => x.Items.Count() > 1).ToList();
                Console.WriteLine();
                foreach (var cart in cartsMoreThan1)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated} Item count: {cart.Items.Count()}");
                }
                var cartsMoreThan1_query = from cart in cartsWithItems where cart.Items.Count() > 1 select cart;
                foreach (var cart in cartsMoreThan1_query)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated} Item count: {cart.Items.Count()}");
                }

                //4. Show only the carts that contain apples
                var cartsWithApples = cartsWithItems.Where(x => x.Items.Any(y => y.Name == "apple"));
                Console.WriteLine();
                foreach (var cart in cartsWithApples)
                {
                    Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
                    foreach(var food in cart.Items)
                    {
                        Console.WriteLine($"Name: {food.Name}");
                    }
                }

                //5. Show the total number of shopping carts
                Console.WriteLine();
                var count = carts.Count();
                Console.WriteLine($"Total number of carts is {count}");

                //6. Show the cart with maximum sum
                Console.WriteLine();
                var cartWithMaximumSum = carts.OrderByDescending(x => x.Sum).FirstOrDefault();
                Console.WriteLine($"Cart created on {cartWithMaximumSum.DateCreated} Sum: {cartWithMaximumSum.Sum}");

                //7. Show the cheapest food
                Console.WriteLine();
                var cheapestFood = foods.OrderByDescending(food => food.Price).ToList().Last();
                Console.WriteLine($"Cheapest food is {cheapestFood.Name} Price: {cheapestFood.Price}");

                //Console.WriteLine("1. Show only the last(latest created) shopping cart with all its items");


                /*IEnumerable <Food> Cart1 =
                    from name in db.Foods
                    select name;
                foreach (var cart in Cart1)
                {
                    Console.WriteLine(cart.Name.Last(), cart.Price);
                }
                */

            }

            //IEnumerable<string> longAnimalNames =
            //from name in animalNames
            //where name.Length >= 5
            //orderby name.Length
            //select name;

        }

        private static void ChooseFood(List<Food> groceries, ShoppingCart newCart)
        {
            Console.WriteLine("What do you want to buy?");
            string foodName = Console.ReadLine();
            Food chosenFood = groceries.FirstOrDefault(x => x.Name == foodName);
            newCart.AddToCart(chosenFood);
            Console.WriteLine("Anything else? Yes/No");
        }

        //1. Show only the last(latest created) shopping cart with all its items
        //2. Show only the carts with Sum > 5
        //3. Show only the carts with more than one item in it(with the number of items)
        //4. Show only the carts that contain bananas
        //5. Show the total number of shopping carts
        //6. Show the cart with maximum sum
        //7. Show the cheapest food
    }
}
