using System;
using System.Threading.Tasks;

namespace ConsoleCanvas
{
    partial class Program
	{
		const char light = '░';
		const char medium = '▒';
		const char dark = '▓';
		const char black = '█';
		const char blackHalfBottom = '▄';
		const char blackHalfTop = '▀';

		public static event Action<ConsoleKeyInfo> OnKeyPress;

		public static bool IsGameRunning = true;
		public static Canvas Canvas;

		//public static Player p1;
		//public static Player p2;

		static void Main(string[] args)
		{
			Canvas = new Canvas();
            Task.Run(StartInputLoop);
            OnKeyPress += (key) => Canvas.AddDrawable(new BouncyBall(key.KeyChar, new Vector(0, 0), Canvas));

            //p1 = new Player(ConsoleKey.UpArrow, ConsoleKey.DownArrow, Canvas.Width - 1);
            //p2 = new Player(ConsoleKey.W, ConsoleKey.S, 0);
            //Canvas.AddDrawable(p1);
            //Canvas.AddDrawable(p2);
            //Canvas.AddDrawable(new PongBall('0', new Point((int)(Canvas.Width * .5), (int)(Canvas.Height * .5))));

            //var x = 0;
            //var y = 0;
            //for(var i = 0; i < Canvas.Width; i++)
            //{
            //    x = (x + 2) % Canvas.Width;
            //    y = (y + 1) % Canvas.Height;
            //    if (y % 5 == 0)
            //        Canvas.AddDrawable(new PhysicsBall('L', new Point(x, 0)));
            //}


            while (true) { }
		}

        //ConsoleKeyInfo _keyPressed = null;
		static Task StartInputLoop()
		{
			while (true)
			{
                var keyPress = Console.ReadKey();
                if (keyPress != null)
				{
                    OnKeyPress?.Invoke(keyPress);
                }
			}
		}
	}
}
