using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public int Battery { get ; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Tesla(int battery, string model, string color)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} 3 with 2 {Battery}";
        }
    }
}
