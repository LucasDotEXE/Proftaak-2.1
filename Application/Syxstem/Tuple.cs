using System;

namespace System
{
    internal class Tuple<T1, T2, T3> : System.Tuple<double, double, double>
    {
        public Tuple(double item1, double item2, double item3) : base(item1, item2, item3)
        {
        }
    }
}