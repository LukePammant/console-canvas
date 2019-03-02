using System;

namespace ConsoleCanvas
{
	public struct Vector
	{
		public float X { get; set; }
		public float Y { get; set; }

		public Vector(float x, float y)
		{
			X = x;
			Y = y;
		}

		public static Vector operator +(Vector a, Vector b)
		{
			return new Vector(a.X + b.X, a.Y + b.Y);
		}

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y);
        }

        public static Vector operator *(Vector a, float b)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        public static Vector Sqrt(Vector a)
        {
            return new Vector((float)Math.Sqrt(a.X), (float)Math.Sqrt(a.Y));
        }

        public float Magnitude()
        {
            var squared = this * this;
            return (float)Math.Sqrt(squared.X + squared.Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
