using System;
using static SampleApp.Sample;
namespace SampleApp
{
    
    public class Program
    {
        
        static void Main(string[] args) 
        {
            Shape shape = new Circle(5);
            shape.Print();  // Output: This is a shape.
            double area = shape.GetArea();
            MathUtils.PrintRounded(area); // Output: Rounded: 79
            Console.ReadLine();


        }
    }
}