using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> multiplyByFive = num => num * 5;
            int result = multiplyByFive(7);
            Console.WriteLine(result);

            List<string> animalNames = new List<string>
            {"fawn", "gibbon", "heron", "ibex", "jackalope"};

            // Result: {"heron", "gibbon", "jackalope"}
            IEnumerable<string> longAnimalNames =
                from name in animalNames
                where name.Length >= 5
                orderby name.Length
                select name;

            //First(), Last(), Single(), ElementAt(0)

            List<double> doubles = new List<double> { 2.0, 2.1, 2.2, 2.3 };
            double whatsThis = doubles.First();

            List<double> doubles = new List<double> { 2.0, 2.1, 2.2, 2.3 };
            double whatsThis = doubles.LastOrDefault(val => val > 2.0 && val < 2.3);
            //Result: 2,2

            Console.WriteLine(longAnimalNames.ElementAt(0));

            //#####################################

            //Take() method
            List<bool> bools = new List<bool> { true, false, true, true, false };
            // Will contain { true, false, true }
            IEnumerable<bool> result = bools.Take(3);

            //Skip() method
            List<bool> bools = new List<bool> { true, false, true, true, false };
            // Will contain { true, true, false }
            IEnumerable<bool> result2 = bools.Skip(2);

            //#####################################

            //TakeWhile(<predicate>) method
            List<int> ints = new List<int> { 1, 2, 4, 8, 4, 2, 1 };
            // Will contain { 1, 2, 4 }
            IEnumerable<int> result = ints.TakeWhile(theInt => theInt < 5);

            //SkipWhile(<predicate>) method
            List<int> ints = new List<int> { 1, 2, 4, 8, 4, 2, 1 };
            // Will contain { 4, 8, 4, 2, 1 }
            IEnumerable<int> result = ints.SkipWhile(theInt => theInt != 4);

            //#####################################

            //Distinct() method
            List<int> ints = new List<int> { 1, 2, 4, 8, 4, 2, 1 };
            // Will contain { 1, 2, 4, 8 }
            IEnumerable<int> result = ints.Distinct();

            //Intersect() method
            List<int> ints = new List<int> { 1, 2, 4, 8, 4, 2, 1 };
            List<int> filter = new List<int> { 1, 1, 2, 3, 5, 8 };
            // Will contain { 1, 2, 8 }
            IEnumerable<int> result = ints.Intersect(filter);

            //Where(<predicate>) method
            List<int> ints = new List<int> { 1, 2, 4, 8, 4, 2, 1 };
            // Will contain { 2, 4, 4, 2 }
            IEnumerable<int> result = ints.Where(theInt => theInt == 2 || theInt == 4);

            //#####################################

            //Reverse() method
            IEnumerable<string> strings = new List<string> { "first", "then", "and then", "finally" };
            // Will contain { "finally", "and then", "then", "first" }
            IEnumerable<string> result = strings.Reverse();

            //OrderBy(<keySelector>) method
            // Sort the strings by the 3rd character
            // Will contain { "and then", "then", "finally", "first" }
            IEnumerable<string> result = strings.OrderBy(str => str[2]);

            //#####################################

            //IOrderedEnumerable<T>
            List<string> strings = new List<string> { "first", "then", "and then", "finally" };
            // Order by the last character, then by the first character
            // Will contain { "and then", "then", "first", "finally" }
            IEnumerable<string> result = strings.OrderBy(str => str.Last()).ThenBy(str => str.First());

            //#####################################

            //Count() method
            IEnumerable<string> strings = new List<string> { "first", "then", "and then", "finally" };
            // Will return 4
            int result = strings.Count();

            //#####################################

            //Sum() method
            IEnumerable<int> ints = new List<int> { 2, 2, 4, 6 };
            // Will return 14
            int result = ints.Sum();

            //Min() and Max() methods
            IEnumerable<int> ints = new List<int> { 2, 2, 4, 6, 3, 6, 5 };
            // Will return 6
            int result = ints.Max();

            //#####################################

            //Any(< predicate >) method
            //Returns true if at least one of the elements in the source sequence matches the provided predicate.Otherwise it returns false.

            IEnumerable<double> doubles = new List<double> { 1.2, 1.7, 2.5, 2.4 };
            // Will return false
            bool result = doubles.Any(val => val < 1);

            //#####################################
        }
    }
}
