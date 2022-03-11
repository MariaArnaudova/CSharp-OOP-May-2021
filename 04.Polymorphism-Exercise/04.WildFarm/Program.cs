using System;
using _04.WildFarm.Models.Foods;
using _04.WildFarm.Models.Animals;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int countLine = -1;
            List<Animal> animlas = new List<Animal>();

            string type = "";
            string name = "";
            double weight = 0;
            string livingRegion = "";
            string breed = "";
            double wingSize = 0;

            while (input != "End")
            {
                countLine++;

                if (countLine % 2 == 0)
                {
                    string[] animalInfo = input.Split();
                    type = animalInfo[0];
                    name = animalInfo[1];
                    weight = double.Parse(animalInfo[2]);

                    if (type == "Cat" || type == "Tiger")
                    {
                        livingRegion = animalInfo[3];
                        breed = animalInfo[4];
                    }
                    else if (type == "Owl" || type == "Hen")
                    {
                        wingSize = double.Parse(animalInfo[3]);
                    }
                    else if (type == "Mouse" || type == "Dog")
                    {
                        livingRegion = animalInfo[3];
                    }
                }
                else
                {
                    string[] foodlInfo = input.Split();

                    string foodType = foodlInfo[0];
                    int quantityFood = int.Parse(foodlInfo[1]);

                    if (foodType == "Fruit")
                    {
                        Food food = new Fruit(quantityFood);
                    }
                    else if (foodType == "Meat")
                    {
                        Food food = new Meat(quantityFood);
                    }
                    else if (foodType == "Seed")
                    {
                        Food food = new Seed(quantityFood);
                    }
                    else if (foodType == "Vegetable")
                    {
                        Food food = new Vegetable(quantityFood);
                    }

                    if (type == "Cat")
                    {
                        Animal cat = new Cat(name, weight, quantityFood, livingRegion, breed);
                        cat.MakeSound();
                        cat.Eat(foodType, quantityFood);
                        animlas.Add(cat);
                    }
                    else if (type == "Tiger")
                    {
                        Animal tiger = new Tiger(name, weight, quantityFood, livingRegion, breed);
                        tiger.MakeSound();
                        tiger.Eat(foodType, quantityFood);
                        animlas.Add(tiger);
                    }
                    else if (type == "Owl")
                    {
                        Animal owl = new Owl(name, weight, quantityFood, wingSize);
                        owl.MakeSound();
                        owl.Eat(foodType, quantityFood);
                        animlas.Add(owl);
                    }
                    else if (type == "Hen")
                    {
                        Animal hen = new Hen(name, weight, quantityFood, wingSize);
                        hen.MakeSound();
                        hen.Eat(foodType, quantityFood);
                        animlas.Add(hen);
                    }
                    else if (type == "Dog")
                    {
                        Animal dog = new Dog(name, weight, quantityFood, livingRegion);
                        dog.MakeSound();
                        dog.Eat(foodType, quantityFood);
                        animlas.Add(dog);
                    }
                    else if (type == "Mouse")
                    {
                        Animal mouse = new Mouse(name, weight, quantityFood, livingRegion);
                        mouse.MakeSound();
                        mouse.Eat(foodType, quantityFood);
                        animlas.Add(mouse);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animlas)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
