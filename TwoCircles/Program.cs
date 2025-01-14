using SFML.Graphics;
using SFML.Learning;
using SFML.System;
using SFML.Window;
using System;

namespace TwoCircles
{
    internal class Program : Game
    {
        static uint windowW = 1000; 
        static uint windowH = 1000;
        static string windowTitle = "Two circles";

        static float outterRadius = 300.0f;
        static float innerRadius = 10.0f;

        static CircleShape innerCircle;
        static CircleShape outterCircle;
        static Game game;

        static float timer = 20000.0f;
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(windowW, windowH), windowTitle);
            window.Closed += (s, e) => window.Close();

            // Создаем круг
            outterCircle = new CircleShape(outterRadius); 
            outterCircle.FillColor = Color.White;
            outterCircle.Origin = new Vector2f(outterCircle.Radius, outterCircle.Radius);
            outterCircle.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);

            // Создаем круг
            innerCircle = new CircleShape(innerRadius);
            innerCircle.FillColor = Color.Red;
            innerCircle.Origin = new Vector2f(innerCircle.Radius, innerCircle.Radius);
            innerCircle.Position = new Vector2f(window.Size.X / 2, window.Size.Y / 2);

            bool spacePressed = false; // Флаг для отслеживания нажатия клавиши Space




            Clock clock = new Clock(); // Создаем часы для отслеживания времени
            // Основной цикл
            while (window.IsOpen)
            {
                window.DispatchEvents();

                // Проверка нажатия клавиши "Space"
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && !spacePressed)
                {
                    outterCircle.Radius = innerCircle.Radius;
                    outterCircle.Origin = new Vector2f(outterCircle.Radius, outterCircle.Radius);
                    spacePressed = true;

                    innerCircle.Radius = 10.0f;
                }
                else if (!Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    spacePressed = false; // Сбрасываем флаг при отпускании клавиши
                }

                window.Clear();

                window.Draw(outterCircle);
                innerCircle.Radius += 0.5f;
                innerCircle.Origin = new Vector2f(innerCircle.Radius, innerCircle.Radius); // Устанавливаем центр круга
                window.Draw(innerCircle);

                if (innerCircle.Radius > outterCircle.Radius)
                {
                    break;
                }

                window.Display();

                // Задержка для ограничения частоты кадров до 60 FPS
                Time elapsed = clock.Restart(); // Получаем время, прошедшее с последнего кадра
                if (elapsed.AsMilliseconds() < 16) // 1000ms / 60fps = ~16ms
                {
                    System.Threading.Thread.Sleep(16 - (int)elapsed.AsMilliseconds()); // Задержка до 16ms
                }
            }



            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();

                Console.WriteLine(  "Lose");


                window.Display();


                // Задержка для ограничения частоты кадров до 60 FPS
                Time elapsed = clock.Restart(); // Получаем время, прошедшее с последнего кадра
                if (elapsed.AsMilliseconds() < 16) // 1000ms / 60fps = ~16ms
                {
                    System.Threading.Thread.Sleep(16 - (int)elapsed.AsMilliseconds()); // Задержка до 16ms
                }
            }
        }
    }
}
