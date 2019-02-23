//using System;

//namespace ConsoleCanvas
//{
//    public class Player : IDrawable
//    {
//        public Vector Position { get; set; }
//        public Vector Velocity { get; set; }
//        public bool GoingUp { get; set; }
//        public bool GoingDown { get; set; }
//        public ConsoleKey UpKey { get; set; }
//        public ConsoleKey DownKey { get; set; }

//        public Player(ConsoleKey up, ConsoleKey down, int column)
//        {
//            UpKey = up;
//            DownKey = down;
//            Position = new Vector(column, 2);
//            Velocity = new Vector(0, 0);
//            OnKeyPress += OnInput;
//        }

//        private void OnInput(ConsoleKey key)
//        {
//            if (key == UpKey)
//            {
//                GoingUp = true;
//                GoingDown = false;
//            }
//            if (key == DownKey)
//            {
//                GoingUp = false;
//                GoingDown = true;
//            }
//        }

//        public void Draw()
//        {
//            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
//            Console.Write('▓');
//            Console.SetCursorPosition((int)Position.X, (int)Position.Y - 1);
//            Console.Write('▓');
//            Console.SetCursorPosition((int)Position.X, (int)Position.Y - 2);
//            Console.Write('▓');
//            Console.SetCursorPosition((int)Position.X, (int)Position.Y + 1);
//            Console.Write('▓');
//            Console.SetCursorPosition((int)Position.X, (int)Position.Y + 2);
//            Console.Write('▓');
//        }

//        public void Update()
//        {
//            if (Position.Y - 3 <= 0)
//                GoingUp = false;
//            if (Position.Y + 3 >= Canvas.Height)
//                GoingDown = false;

//            if (GoingUp)
//                Position += new Vector(0, -1);
//            if (GoingDown)
//                Position += new Vector(0, 1);
//        }
//    }
//}
