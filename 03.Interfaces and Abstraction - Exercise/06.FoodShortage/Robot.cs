using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Robot : IIdentifiable
    {
        public Robot(string name, string id)
        {
            Model = name;
            Id = id;
        }
        public string Model { get; private set; }
        public string Id { get; private set; }
    }
}
