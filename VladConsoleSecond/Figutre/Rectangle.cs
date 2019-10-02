using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figutre
{
    class Rectangle : Figure
    {
        public override double S { set; get; }

        public override double P { set; get; }

        public override double C { set; get; }

        public override void PResult(int a, int b)
        {
            P = a + b;
        }
        public override void SResult(int a, int b)
        {
            S = a * b;
        }

        public override void CResult(double a)
        {

        }

        public override void SRResult(double a)
        {

        }
    }
}
