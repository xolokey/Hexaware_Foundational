using System;
namespace SampleApp
{

    public class Sample
    {
        public abstract class Shape
        {
            public abstract double GetArea();

            public void Print()
            {
                Console.WriteLine("This is a shape.");
            }
        }

        public class Circle : Shape
        {
            private double radius;

            public Circle(double r) { radius = r; }

            public override double GetArea() => Math.PI * radius * radius;
        }

        public static class MathUtils
        {
            public static void PrintRounded(double value)
            {
                Console.WriteLine("Rounded: " + Math.Round(value));
            }
        }

    }
}
