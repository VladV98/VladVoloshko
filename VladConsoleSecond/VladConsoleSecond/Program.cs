using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladConsoleSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Food> groceries = new List<Food>
            {
                new Food("banana", 1.2),
                new Food("potatoes", 1),
                new Food("icecream", 2.5)
            };

            //Client
            Console.WriteLine("Please enter your first name!");
            string firstName = Console.ReadLine();

            Console.WriteLine("Hi, " + firstName + "! Please enter your last name:");
            string lastName = Console.ReadLine();

            Person client = new Person(firstName, lastName);

            Console.WriteLine("Welcome to our shop, " + client + "!");
            client.ShoppingCart = new ShoppingCart();

            ChooseFood(groceries, client);// Выделяем - Edit - Refactor - Extract Method
            while (Console.ReadLine() == "Y")
            {
                ChooseFood(groceries, client);
            }
            double sum = client.ShoppingCart.CalculateSum();
            Console.WriteLine("Your total is " + sum + " Thank you for visiting!");
        }

        private static void ChooseFood(List<Food> groceries, Person client)
        {
            Console.WriteLine("What do you want to buy?");
            string foodName = Console.ReadLine();
            Food chosenFood = groceries.FirstOrDefault(x => x.Name == foodName);//Запрос: Ищет введенный товар, в лист Food
            if (chosenFood == null)
            {
                Console.WriteLine("Excuse me, we don't have " + foodName + " in our shop :( ");
            }
            else
            {
                Console.WriteLine("How much?");
                string amount = Console.ReadLine();
                int a;
                bool success = int.TryParse(amount, out a);//Конвентирует стринг в инт. amount - что входит, а - что выводится
                while (!success)
                {
                    Console.WriteLine("Escuse me, amount shoud be integer value: ");
                    amount = Console.ReadLine();
                    success = int.TryParse(amount, out a);
                }

                client.ShoppingCart.AddToCart(chosenFood, a);
            }
            Console.WriteLine("Anything else? Y/N");
        }
    }
}
