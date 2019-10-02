using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animal
{
    class Bird: Animal
    {
        public override void Talk()
        {
            Console.Write("Birds sing");
        }

        public override int legN
        {
            get { return 2; }
        }
    }
}
