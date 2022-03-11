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
    }
}
