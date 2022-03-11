using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {

        private readonly int width;
        private readonly int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine('*', '*');
            for (int i = 0; i < height-2; i++)
            {
                DrawLine('*', ' ');
            }
            DrawLine('*', '*');
        }

        private void DrawLine(char bounday, char inner)
        {
            Console.WriteLine($"{bounday}{new string(inner, width-2)}{bounday}");
        }
    }
}
