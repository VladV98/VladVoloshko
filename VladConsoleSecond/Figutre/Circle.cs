using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figutre
{
    class Circle : Figure
    {
        double pi = Math.PI;

        public override double S { set; get; }

        public override double P { set; get; }

        public override double C { set; get; }


        public override void PResult(int a, int b)
        {

        }
        public override void SResult(int a, int b)
        {

        }
    

        public override void CResult(double a)
        {
            C = 2 * pi * a;
        }
        public override void SRResult(double a)
        {
           S  = pi * a * a;
        }
    }
}
