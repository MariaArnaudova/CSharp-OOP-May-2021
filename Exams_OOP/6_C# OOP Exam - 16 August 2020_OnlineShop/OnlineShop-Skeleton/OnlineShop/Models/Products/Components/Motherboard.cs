using System;
using System.Collections.Generic;
using OnlineShop.Models.Products.Components;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public class Motherboard : Component
    {
        private const double Multiplier = 1.25;
        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {

        }

        public override double OverallPerformance => base.OverallPerformance * Multiplier;
    }
}
