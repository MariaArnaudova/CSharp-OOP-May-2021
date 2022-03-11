using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IRace> raceRepo;
        private IRepository<IDriver> driverRepository;
        private IRepository<ICar> carRepository;

        public ChampionshipController()
        {
            this.raceRepo = new RaceRepository();
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {

            IDriver driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar searchedCar = carRepository.GetByName(carModel);
            if (searchedCar == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(searchedCar);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);

        }

        public string AddDriverToRace(string raceName, string driverName)
        {

            IRace race = raceRepo.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = default;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            ICar searchedCar = carRepository.GetByName(model);
            if (searchedCar != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName) //!!!!!!!!!
        {
            IDriver driver = new Driver(driverName);
            IDriver newDriver = driverRepository.GetByName(driverName);

            if (newDriver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            driverRepository.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps) // !!!!!!!!!!!
        {
            IRace race = new Race(name, laps);

            IRace sameRace = raceRepo.GetByName(name);

            if (sameRace != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            this.raceRepo.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepo.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IDriver[] fasterDrivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();
            raceRepo.Remove(race);

            StringBuilder sb = new StringBuilder();
    
            sb.AppendLine($"Driver {fasterDrivers[0].Name } wins { raceName} race.");
            sb.AppendLine($"Driver { fasterDrivers[1].Name} is second in { raceName} race.");
            sb.AppendLine($"Driver { fasterDrivers[2].Name} is third in { raceName} race.");
            return sb.ToString().TrimEnd();
        }
    }
}
