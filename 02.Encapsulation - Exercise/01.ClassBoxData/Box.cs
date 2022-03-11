using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width 
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height 
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea(double l, double w, double h)
        {
            double surfaceArea = 2*l*w + 2*l*h + 2*w*h;
            return surfaceArea;
        }

        public double LateralSurfaceArea(double l, double w, double h)
        {
            double lateralSurfaceArea = 2 * l * h + 2 * w * h;

            return lateralSurfaceArea;
        }
      
        public double Volume(double l, double w, double h)
        {
            double volume = l * w * h;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea(length, width, height):f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea(length, width, height):f2}");
            sb.Append($"Volume - {this.Volume(length, width, height):f2}");
            return sb.ToString();
        }

    }
}
