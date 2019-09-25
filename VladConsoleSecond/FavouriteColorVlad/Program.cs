using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladConsoleSecond;

namespace FavouriteColorVlad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            //string[] lines = File.ReadAllLines(@"C:\Users\opilane\Desktop\VladConsoleSecond\list.txt");

            string[] lines = File.ReadAllLines("list.txt");

            foreach(var line in lines)
            {
                var names = line.Split(' ');
                Person person = new Person(names[0], names[1]);
                people.Add(person);
            }

            Console.WriteLine("Hi! Please enter your last name: ");
            string lastName = Console.ReadLine();

            Person someone = people.FirstOrDefault(x => x.LastName == lastName);
            Console.WriteLine($"Hi, {someone.FirstName}! What's your favourite color?");
            var answer = Console.ReadLine();

            Enum.TryParse(answer, true, out Color favouriteColor);
            someone.FavouriteColor = favouriteColor;

            using (StreamWriter file = new StreamWriter("list2.txt"))
            {
                file.WriteLine($"{someone.FirstName} {someone.LastName} Favourite color: {someone.FavouriteColor}");
            }

            //Создаём и указываем путь каталога
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine($"{someone.FirstName} {someone.LastName} Favourite color: {someone.FavouriteColor}");
            }
        }
    }
}
