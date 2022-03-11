using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }
        public override double CalculateArea()
        {
            double rectangleArea = 0;
            return rectangleArea = Height * Width;
        }

        public override double CalculatePerimeter()
        {
            double rectanglePerimeter = 0;
            return rectanglePerimeter = 2 * (Height+Width);
        }
        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }


    }
}
