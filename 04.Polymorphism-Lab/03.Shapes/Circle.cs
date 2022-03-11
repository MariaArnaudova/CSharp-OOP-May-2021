using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }
        public override double CalculateArea()
        {
            double circleArea = 0;
            return circleArea = Math.PI * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            double circlePerimerter = 0;
            return circlePerimerter = 2 * Math.PI * Radius;
        }

        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }
    }
}
