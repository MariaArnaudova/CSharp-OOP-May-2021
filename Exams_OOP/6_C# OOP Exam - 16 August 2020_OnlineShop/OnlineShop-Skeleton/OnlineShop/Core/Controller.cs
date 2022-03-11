
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
namespace OnlineShop.Core
{
    using OnlineShop.Common.Constants;
    using OnlineShop.Models.Products.Computers;
    using OnlineShop.Models.Products.Peripherals;
    using OnlineShop.Models.Products.Components;
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (computer.Components.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponentId));
            }


            IComponent component = default;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComponentType));
            }


            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponentId));
            }

            computer.AddComponent(component);
            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = default;

            if (computerType == nameof(Laptop))
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }


            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComputerId));
            }

            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral peripheral = default;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }


            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            computer.AddPeripheral(peripheral);  /// da se izmesti otdoulu
            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {

            var computer = this.computers
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault(x => x.Price <= budget);

            if (this.computers.Count == 0 || this.computers.All(x => x.Price > budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);

            return computer.ToString();


        }

        public string BuyComputer(int id) // greshka pri ToString
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (!this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            this.computers.Remove(computer);

            return computer.ToString();

        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComponent removerdComponent = computer.Components
                                           .FirstOrDefault(x => x.GetType().Name == componentType);
            if (removerdComponent == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, computer.GetType().Name, computerId));

            }
            computer.RemoveComponent(componentType);
            this.components.Remove(removerdComponent);
            return string.Format(SuccessMessages.RemovedComponent, componentType, removerdComponent.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {

            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral removePeripheral = computer.Peripherals
                                           .FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (removePeripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, computer.GetType().Name, computerId));
            }

            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(removePeripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, removePeripheral.Id);
        }
    }
}
