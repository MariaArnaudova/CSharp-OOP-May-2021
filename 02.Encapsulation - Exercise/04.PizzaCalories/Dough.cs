using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string backingTechnique;
        private double weight;
        public Dough(string flourType, string backingTechType, double weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechType;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (!DoughValidator.IsValidFlourTupe(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BackingTechnique
        {
            get
            {
                return backingTechnique;

            }
            set
            {
                if (!DoughValidator.IsValidBackingTechnique(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                backingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {
            //    double calories = 0;
            return this.Weight
                  * 2
                  * DoughValidator.GetBackingTechiqueModifier(this.backingTechnique)
                  * DoughValidator.GetFlourModifier(this.flourType);
        }
    }
}
