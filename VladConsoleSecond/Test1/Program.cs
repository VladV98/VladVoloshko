using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>
            {
                new Students("Vlad", "Voloshko", "12525865882", "IsStuding"),
                new Students("Nikita", "Harkov", "12356841233", "IsStuding")
            };

        }
    }
}
