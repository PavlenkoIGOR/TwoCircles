using SFML.Graphics;
using SFML.Learning;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TwoCircles
{
    internal class Program : Game
    {
        static uint windowW = 800; 
        static uint windowH = 800;
        static string windowTitle = "Two circles";

        static float outterRadius = 200.0f;
        static float innerRadius = 10.0f;

        static string circlesSprite = LoadTexture("Circles.png");

        static CircleShape innerCircleShape;
        static CircleShape outterCircleShape;

        static float timer = 20000.0f;
        static void Main(string[] args)
        {
            //RenderWindow rw = new RenderWindow(new VideoMode(windowW, windowH), windowTitle);
            InitWindow(windowW, windowH, windowTitle);

            outterCircleShape = new CircleShape(50); // Радиус круга
            outterCircleShape.FillColor = Color.Yellow; // Цвет заливки
            outterCircleShape.Origin = new Vector2f(outterRadius, outterRadius); // Устанавливаем центр круга
            outterCircleShape.Position = new Vector2f(windowW / 2, windowH / 2); // Центрируем круг в окне

            while (true)
            {
                DispatchEvents();
                ClearWindow();

                #region game
                DrawSprite(circlesSprite, 10, 10, 0, 0, 1440, 720);
                Console.WriteLine($"{timer}");
                timer -= DeltaTime;

                #endregion

                DisplayWindow();
                Delay(1);
            }
        }
    }
}
