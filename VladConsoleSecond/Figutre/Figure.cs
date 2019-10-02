using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figutre
{
    abstract class Figure
    {
        public abstract double S  { set; get; }

        public abstract double P { set; get; }

        public abstract double C { set; get; }

        public abstract void PResult(int a, int b);

        public abstract void SResult(int a, int b);

        public abstract void CResult(double a);

        public abstract void SRResult(double a);
    }
}
