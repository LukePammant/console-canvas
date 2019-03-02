using System;

namespace ConsoleCanvas
{
    public class Line : IDrawable
    {
        public Vector _start;
        public Vector _end;
        public char? _shape;

        private const char halfLeft = '▌';
        private const char halfRight = '▐';

        public Line(Vector start, Vector end)
        {
            _start = start;
            _end = end;
        }

        public Line(Vector start, Vector end, char shape) : this(start, end)
        {
            _shape = shape;
        }

        public void Draw()
        {
            var direction = _end - _start;
            var magnitude = direction.Magnitude();
            var stepDistance = direction * (1 / magnitude);

            for (var step = (int)magnitude; step > 0; step--)
            {
                var position = _start + (stepDistance * step);
                var shape = _shape ??
                            ((position.X - Math.Truncate(position.X)) < .5 ? halfLeft : halfRight);
                Console.SetCursorPosition((int)Math.Floor(position.X), (int)Math.Floor(position.Y));
                Console.Write(shape);
            }
        }

        public void Update()
        {
        }
    }
}
