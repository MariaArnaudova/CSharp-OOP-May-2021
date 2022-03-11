using System;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] phoneNumbers = Console.ReadLine().Split(' ');
            string[] sites = Console.ReadLine().Split(' ');

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                try
                {
                    if (phoneNumbers[i].Length == 10)
                    {
                       
                        Console.WriteLine(smartPhone.Call(phoneNumbers[i]));

                    }
                    else if (phoneNumbers[i].Length == 7)
                    {
                        
                        Console.WriteLine(stationaryPhone.Call(phoneNumbers[i]));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
          
            for (int i = 0; i < sites.Length; i++)
            {

                try
                {                 
                    Console.WriteLine(smartPhone.Browse(sites[i]));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
