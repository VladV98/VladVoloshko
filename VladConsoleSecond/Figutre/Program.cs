using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figutre
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle();
            rc.PResult(2, 4);
            rc.SResult(2, 4);

            Circle cr = new Circle();
            cr.CResult(2);
            cr.SRResult(5);
        }
    }
}
