using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Group
    {
        public List<Students> TARgv18 { get; set; }

        public List<Students> TARgv19 { get; set; }

        public Group()
        {
            TARgv18 = new List<Students>();
            TARgv19 = new List<Students>();
        }

        public void AddToGroup(Students students)
        {
            TARgv18.Add(students);
        }
    }
}
