//using System;

//namespace ConsoleCanvas
//{
//    public class PongBall : IDrawable
//    {
//        public Vector Position { get; set; }
//        public Vector Velocity { get; set; }
//        public char Shape { get; set; }

//        public PongBall(char shape, Vector position)
//        {
//            Velocity = new Vector(1, 1);
//            Position = position;
//            Shape = shape;
//        }

//        public void Draw()
//        {
//            Console.SetCursorPosition((int)Math.Floor(Position.X), (int)Math.Floor(Position.Y));
//            Console.Write(Shape);
//        }

//        public void Update()
//        {
//            Position += Velocity;

//            if ((int)Position.Y >= Canvas.Height || (int)Position.Y <= 0)
//            {
//                Velocity.Y *= -1;

//                if ((int)Position.Y >= Canvas.Height)
//                    Position.Y = Canvas.Height - 1;
//                if ((int)Position.Y <= 0)
//                    Position.Y = 0;
//            }

//            if ((int)Position.X >= Canvas.Width || (int)Position.X <= 0)
//            {
//                // if player position is within 2 'units'
//                if (Position.Y != p1.Position.Y &&
//                    Position.Y != p1.Position.Y - 1 &&
//                    Position.Y != p1.Position.Y - 2 &&
//                    Position.Y != p1.Position.Y + 1 &&
//                    Position.Y != p1.Position.Y + 2 &&
//                    Position.Y != p2.Position.Y &&
//                    Position.Y != p2.Position.Y - 1 &&
//                    Position.Y != p2.Position.Y - 2 &&
//                    Position.Y != p2.Position.Y + 1 &&
//                    Position.Y != p2.Position.Y + 2)
//                {
//                    IsGameRunning = false;
//                    Console.WriteLine("DEAD!");
//                }

//                Velocity.X *= -1;

//                if ((int)Position.X >= Canvas.Width)
//                    Position.X = Canvas.Width - 1;
//                if ((int)Position.X <= 0)
//                    Position.X = 0;
//            }
//        }
//    }
//}
