using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (input != "Beast!")
            {
                string animal = input;
                string[] animalTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (animal!= null)
                {
                    continue;
                }
   
                string name = animalTokens[0];
                int age = int.Parse(animalTokens[1]);
                string gender = animalTokens[2];
                
                if (animal=="Dog")
                {
                    try
                    {                      
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                
                }
                else if (animal =="Cat")
                {
                    try
                    {
                       
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);                     
                    }            
                }
                else if (animal =="Frog")
                {
                    try
                    {                      
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);       
                    }                
                }
                else if (animal == "Kittens")
                {
                    try
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);                
                    }                  
                }
                else if (animal== "Tomcat")
                {
                    try
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat); 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }  
                }
                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

    }
}

