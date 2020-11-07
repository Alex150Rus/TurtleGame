using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = GraphicsWindow.Width = 600;
            int height = GraphicsWindow.Height = 600;

            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            //убрать шлейф за черепашкой
            Turtle.PenUp();

            GraphicsWindow.BrushColor = "red";
            var eat = Shapes.AddRectangle(10, 10);
            int x = 200;
            int y = 200;
            Shapes.Move(eat, x, y);

            Random rand = new Random();

            while (true)
            {
                Turtle.Move(10);
                if ((Turtle.X <= 0 && Turtle.Angle == 270) || (Turtle.X >= GraphicsWindow.Width && Turtle.Angle == 90) || 
                    (Turtle.Y <= 0 && Turtle.Angle == 0) || (Turtle.Y >= GraphicsWindow.Height && Turtle.Angle == 180))
                {
                    Turtle.Turn(180);
                }

                if (Turtle.X >= x && Turtle.X <= x+10 && Turtle.Y >= y && Turtle.Y <= y+10)
                {
                    x = rand.Next(0, GraphicsWindow.Width);
                    y = rand.Next(0, GraphicsWindow.Height);
                    Shapes.Move(eat, x, y);
                    Turtle.Speed++;
                }
            }
        }

        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up") {
                Turtle.Angle = 0;
            } else if(GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            } else if (GraphicsWindow.LastKey == "Down")
            {
                Turtle.Angle = 180;
            } else if(GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
        }
    }
}
