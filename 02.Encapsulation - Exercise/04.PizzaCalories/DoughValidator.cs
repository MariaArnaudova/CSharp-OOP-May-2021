using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
   public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTchniques;
   
        public static bool IsValidFlourTupe(string type)
        {
            Initialize();
            return flourTypes.ContainsKey(type.ToLower());
        }
        public static bool IsValidBackingTechnique(string type)
        {
            Initialize();
            return bakingTchniques.ContainsKey(type.ToLower());
        }
        public static double GetFlourModifier(string type)
        {
            Initialize();
            return flourTypes[type.ToLower()];
        }
           
        public static double GetBackingTechiqueModifier(string type)
        {
            Initialize();
            return bakingTchniques[type.ToLower()];
        }
           
        private static void Initialize()
        {
            if (flourTypes != null || bakingTchniques != null)
            {
                return;
            }
            flourTypes = new Dictionary<string, double>();
            bakingTchniques = new Dictionary<string, double>();

            flourTypes.Add("white", 1.5);
            flourTypes.Add("wholegrain", 1.0);

            bakingTchniques.Add("crispy", 0.9);
            bakingTchniques.Add("chewy", 1.1);
            bakingTchniques.Add("homemade", 1.0);
        }
    }
}
