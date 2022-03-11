﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
   public class Tracker
    {       
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {

                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    object[] attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in attributes)
                    {

                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
             
            }
        }
    }
}
