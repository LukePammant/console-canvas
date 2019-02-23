using System;
using System.Collections.Generic;

namespace ConsoleCanvas
{
    public class BouncyBall : IDrawable, IPhysicsObject
    {
        public char Shape { get; private set; }
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public List<IPhysicsRule> physicsRules { get; set; }

        public BouncyBall(char shape, Vector position, Canvas canvas)
        {
            var dampening = .4f;

            physicsRules = new List<IPhysicsRule>();
            physicsRules.Add(new BounceOffSideOfScreen(canvas, dampening));
            physicsRules.Add(new Gravity());

            Velocity = new Vector(1, 1);
            Position = position;
            Shape = shape;
        }

        public void Draw()
        {
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            Console.Write(Shape);
        }

        public void Update()
        {
            Position += Velocity;

            foreach(var rule in physicsRules)
            {
                rule.Apply(this);
            }
        }
    }
}
