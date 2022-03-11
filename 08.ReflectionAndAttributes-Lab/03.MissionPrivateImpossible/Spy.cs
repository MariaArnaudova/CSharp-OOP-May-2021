using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requetedFieldsNames)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance
                | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: { investigatedClass}");

            classFields = classFields.Where(f => requetedFieldsNames.Contains(f.Name)).ToArray();

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string invesigatedClass)
        {
            Type classType = Type.GetType(invesigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonePublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            classNonePublicMethods = classNonePublicMethods.Where(m => m.Name.StartsWith("get")).ToArray();

            foreach (MethodInfo method in classNonePublicMethods)
            {
                sb.AppendLine($"{ method.Name} have to be public!");
            }

            classPublicMethods = classPublicMethods.Where(m => m.Name.StartsWith("set")).ToArray();

            foreach (MethodInfo method in classPublicMethods)
            {
                sb.AppendLine($"{ method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string invesigatedClass)
        {
            Type classType = Type.GetType(invesigatedClass);

            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {classType}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                sb.AppendLine(method.Name);
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
