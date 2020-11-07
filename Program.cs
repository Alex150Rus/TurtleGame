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
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            //убрать шлейф за черепашкой
            Turtle.PenUp();

            GraphicsWindow.BrushColor = "red";
            var eat = Shapes.AddRectangle(10, 10);
            Shapes.Move(eat, 200, 200);
            
            while (true)
            {
                Turtle.Move(10);
                if (Turtle.X == Shapes.GetLeft(eat) && Turtle.Y == 200)
                {
                    Shapes.Move(eat, Turtle.X + 10, 200);
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
