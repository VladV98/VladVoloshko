using System;
using System.Collections.Generic;

namespace Vlad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int x = 5;
            int y = 10;

            int z = x + y;
            Console.WriteLine(z);

            double a = 1.5;
            double b = 0.4;

            double c = a * b;
            Console.WriteLine(c);

            string name = "Vlad Voloshko";
            string x1 = "5";
            string x2 = "10";

            string x3 = x1 + x2;
            Console.WriteLine(x3);

            char d = 'a';
            char e = 'b';

            bool isStuding = true;
            bool isWorking = false;

            bool boolValue = isStuding && isWorking;
            Console.WriteLine(boolValue);

            bool boolValue2 = isStuding || isWorking;
            Console.WriteLine(boolValue2);

            int h = 20;
            if (h > 0)
            {
                Console.WriteLine("Positive number");
            }
            else if (h < 0)
            {
                Console.WriteLine("Negative number");
            }
            else
            {
                Console.WriteLine("Zero");
            }

            bool m = (x == y);
            switch (m)
            {
                case true :
                      Console.WriteLine("X and Y are equal");
                    break;

                case false:
                    Console.WriteLine("X and Y are not equal");
                    break;
            }

            int[] numbers = { 1, 0, -2, 10 }; //massiv
            List<int> numberList = new List<int> { 1, 0, -2, 10 }; //list
            numberList.Add(5);

            int firstNumber = numbers[0];
            Console.WriteLine(firstNumber);
            int firstListElement = numberList[0];
            Console.WriteLine(firstListElement);

            int element = numberList[4];
            Console.WriteLine(element);

            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }
            for(int i = 0; i < numberList.Count; i++)
            {
                Console.WriteLine(numberList[i]);
            }
            Console.WriteLine();
            int index = 0;
            while(index < numberList.Count)
            {
                Console.WriteLine(numberList[index]);
                index+=2;
            }

            Food sweets = new Food("Sweets", 5);
            Console.WriteLine(sweets.Name);
            Console.WriteLine(sweets.Price);

            sweets.Price = 6;
            Console.WriteLine(sweets.Price);

            Food apples = new Food("Apples", 3);
            Food banana = new Food("Banana", 4);

            Food[] groceries = { sweets, banana, apples };
            Console.WriteLine(groceries[1].Name);
            apples.Price = 2;
            Console.WriteLine(groceries[2].Price);

            ShoppingCart myCart = new ShoppingCart();
            myCart.AddToCart(sweets, 3);
            myCart.AddToCart(banana, 5);

            Console.WriteLine();
            Console.WriteLine("Total Sum: " + myCart.Sum);
            Console.WriteLine();

            DetailedShoppingCart detailedCart = new DetailedShoppingCart();

            Console.WriteLine("////////////////////////////////////////////////////////////////////////////");
            detailedCart.AddToCart(sweets, 3);
            detailedCart.AddToCart(banana, 5);
            Console.WriteLine("Total Sum: " + detailedCart.Sum);


        }
    }
}
