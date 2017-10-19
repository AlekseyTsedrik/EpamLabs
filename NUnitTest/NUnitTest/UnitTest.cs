using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class UnitTest
    {
        [Test]
        public static void TestSum1()
        {
            Console.WriteLine("TestSum1");
            double actual = Calculator.Sum(2, 3);
            Assert.AreEqual(5, actual);
        }

        [Test]
        public static void TestSum2()
        {
            Console.WriteLine("TestSum2");
            Assert.AreEqual(6, Calculator.Sum(-7, 13));
        }

        [Test]
        public static void TestSum3()
        {
            Console.WriteLine("TestSum3");
            Assert.AreEqual(6.875, Calculator.Sum(2.618, 4.257));
        }

        [Test]
        public static void TestSum4()
        {
            Console.WriteLine("TestSum4");
            Assert.AreEqual(0, Calculator.Sum(-5, 5));
        }

        [Test]
        public static void TestSum5()
        {
            Console.WriteLine("TestSum5");
            Assert.AreEqual(-15.878, Calculator.Sum(-5, -10.878));
        }

        [Test]
        public static void TestDifference1()
        {
            Console.WriteLine("TestDifference1");
            Assert.AreEqual(2, Calculator.Difference(4, 2));
        }

        [Test]
        public static void TestDifference2()
        {
            Console.WriteLine("TestDifference1");
            Assert.AreEqual(0, Calculator.Difference(91, 91));
        }

        [Test]
        public static void TestDifference3()
        {
            Console.WriteLine("TestDifference3");
            Assert.AreEqual(-15, Calculator.Difference(30, 45));
        }

        [Test]
        public static void TestDifference4()
        {
            Console.WriteLine("TestDifference4");
            Assert.AreEqual(-5.984, Calculator.Difference(2.161, 8.145));
        }

        [Test]
        public static void TestDifference5()
        {
            Console.WriteLine("TestDifference5");
            Assert.AreEqual(10, Calculator.Difference(-5, -15));
        }

        [Test]
        public static void TestMultiplication1()
        {
            Console.WriteLine("TestMultiplication1");
            Assert.AreEqual(20, Calculator.Multiplication(2, 10));
        }

        [Test]
        public static void TestMultiplication2()
        {
            Console.WriteLine("TestMultiplication2");
            Assert.AreEqual(-15, Calculator.Multiplication(3, -5));
        }

        [Test]
        public static void TestMultiplication3()
        {
            Console.WriteLine("TestMultiplication3");
            Assert.AreEqual(12.375, Calculator.Multiplication(2.75, 4.5));
        }

        [Test]
        public static void TestMultiplication4()
        {
            Console.WriteLine("TestMultiplication4");
            Assert.AreEqual(0, Calculator.Multiplication(2, 0));
        }

        [Test]
        public static void TestMultiplication5()
        {
            Console.WriteLine("TestMultiplication5");
            Assert.AreEqual(30, Calculator.Multiplication(-15, -2));
        }

        [Test]
        public static void TestDivision1()
        {
            Console.WriteLine("TestDivision1");
            Assert.AreEqual(15, Calculator.Division(30, 2));
        }

        [Test]
        public static void TestDivision2()
        {
            Console.WriteLine("TestDivision2");
            Assert.AreEqual(-2, Calculator.Division(-10, 5));
        }

        [Test]
        public static void TestDivision3()
        {
            Console.WriteLine("TestDivision3");
            Assert.AreEqual(8.1, Calculator.Division(16.2, 2));
        }

        [Test]
        public static void TestDivision4()
        {
            Console.WriteLine("TestDivision4");
            Assert.AreEqual(Double.NaN, Calculator.Division(0, 0));
        }

        [Test]
        public static void TestDivision5()
        {
            Console.WriteLine("TestDivision5");
            Assert.AreEqual(Double.PositiveInfinity, Calculator.Division(5, 0));
        }
    }
}
