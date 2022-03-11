using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
       
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }


        //public override double OverallPerformance => this.components.Count == 0 ? base.OverallPerformance : AverageOverallPerformance();
        public override double OverallPerformance ///!!! vajno
        {
            get
            {
                if (!this.Components.Any())
                {
                    return base.OverallPerformance;
                }

                var componentsAveragePerformance = this.Components.Any() ? this.Components.Average(c => c.OverallPerformance) : 0;

                return base.OverallPerformance + componentsAveragePerformance;
            }
        }
        public override decimal Price => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            string componentType = component.GetType().Name;

            if (this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string periferalsType =peripheral.GetType().Name;

            if (this.peripherals.Any(x => x.GetType().Name == periferalsType))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent searchedComponent = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (this.components.Count == 0 ||this.components.All(x => x.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(searchedComponent);
            return searchedComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {

            IPeripheral searchedPeripheral = this.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (this.peripherals.Count == 0 ||this.peripherals.All(x => x.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id ));
            }

            this.peripherals.Remove(searchedPeripheral);
            return searchedPeripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(base.ToString());
            //sb.AppendLine($" Components ({this.components.Count}):");
            //sb.AppendLine($"  {string.Join("", this.components)}");
            //sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({AverageOverallPerformance():f2}):");
            //sb.AppendLine($"  {string.Join("", this.peripherals)}");

            //return sb.ToString().TrimEnd();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({AverageOverallPerformance():f2}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();

        }

        public double AverageOverallPerformance()
        {
            if (this.peripherals.Count == 0)
            {
                return 0;
            }

            return  this.peripherals.Average(x => x.OverallPerformance);
        }
    }
}
