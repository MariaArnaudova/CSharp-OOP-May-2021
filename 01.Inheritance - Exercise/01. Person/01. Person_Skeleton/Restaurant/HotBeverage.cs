using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
   public class HotBeverage :Beverage
    {
        public HotBeverage(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {
            
        }
     
        // string name, decimal price, double milliliters.
        //Reuse the constructor of the inherited class.
       
    }
}
