using System;
using System.Threading.Tasks;

namespace ConsoleCanvas
{
    internal partial class Program
    {
        // http://www.asciitable.com/
        private const char light = '░';
        private const char medium = '▒';
        private const char dark = '▓';
        private const char black = '█';
        private const char blackHalfLeft = '▌';
        private const char blackHalfRight = '▐';
        private const char blackHalfBottom = '▄';
        private const char blackHalfTop = '▀';

        public static event Action<ConsoleKeyInfo> OnKeyPress;

        public static bool IsGameRunning = true;
        public static Canvas Canvas;

        //public static Player p1;
        //public static Player p2;

        private static void Main(string[] args)
        {
            Canvas = new Canvas();
            Task.Run(StartInputLoop);

            // Register even to spawn a character for each key press
            // TODO: Only listen for key letter/number key presses. Arrow keys, etc. shouldn't spawn empty characters
            OnKeyPress += (key) => 
                Canvas.AddDrawable(new BouncyBall(key.KeyChar, new Vector(0, 0), Canvas));

            //p1 = new Player(ConsoleKey.UpArrow, ConsoleKey.DownArrow, Canvas.Width - 1);
            //p2 = new Player(ConsoleKey.W, ConsoleKey.S, 0);
            //Canvas.AddDrawable(p1);
            //Canvas.AddDrawable(p2);
            //Canvas.AddDrawable(new PongBall('0', new Point((int)(Canvas.Width * .5), (int)(Canvas.Height * .5))));

            var line = new Line(new Vector(5, 5), new Vector(13, 30));
            Canvas.AddDrawable(line);
            OnKeyPress += (key) =>
            {
                if (key.Key == ConsoleKey.LeftArrow)
                    line._end = line._end + new Vector(-1, 0);
                if (key.Key == ConsoleKey.RightArrow)
                    line._end = line._end + new Vector(1, 0);
                if (key.Key == ConsoleKey.UpArrow)
                    line._end = line._end + new Vector(0, -1);
                if (key.Key == ConsoleKey.DownArrow)
                    line._end = line._end + new Vector(0, 1);
            };

            while (true) { }
        }

        private static Task StartInputLoop()
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
