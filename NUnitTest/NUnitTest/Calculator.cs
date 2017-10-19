using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    class Calculator
    {
        public static double Sum(double fisrt, double second)
        {
            return fisrt + second;
        }

        public static double Difference(double first, double second)
        {
            return first - second;
        }

        public static double Multiplication(double first, double second)
        {
            return first * second;
        }

        public static double Division(double first, double second)
        {
            return first / second;
        }
    }
}
