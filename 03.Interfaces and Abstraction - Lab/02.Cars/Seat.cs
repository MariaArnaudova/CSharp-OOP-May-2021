using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get ; set ; }
        public string Color { get; set ; }

  
        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }

    }
}
