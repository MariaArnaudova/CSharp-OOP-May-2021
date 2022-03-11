using System;

namespace ClassBoxData
{
   public class Program
    {
        static void Main(string[] args)
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double heidht = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, heidht);
                Console.WriteLine(box);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
