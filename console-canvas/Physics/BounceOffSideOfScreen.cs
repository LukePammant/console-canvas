using System;

namespace ConsoleCanvas
{
    internal class BounceOffSideOfScreen : IPhysicsRule
    {
        private Canvas _canvas;
        private readonly float _dampening;

        public BounceOffSideOfScreen(Canvas canvas, float dampening)
        {
            _canvas = canvas;
            _dampening = 1 - dampening;
        }

        public void Apply(IPhysicsObject physicsObject)
        {
            var position = physicsObject.Position;
            var velocity = physicsObject.Velocity;

            if ((int)position.Y >= _canvas.Height)
            {
                velocity.Y *= _dampening * -1;
                velocity.Y = Math.Abs(velocity.Y) < 0.3 ? 0 : velocity.Y;
                position.Y = Math.Clamp(position.Y, 0, _canvas.Height - 1);
            }

            if ((int)position.X >= _canvas.Width || (int)position.X <= 0)
            {
                velocity.X *= _dampening * -1;
                velocity.X = Math.Abs(velocity.X) < 0.3 ? 0 : velocity.X;
                position.X = Math.Clamp(position.X, 0, _canvas.Width - 1);
            }

            physicsObject.Position = position;
            physicsObject.Velocity = velocity;
        }
    }
}
