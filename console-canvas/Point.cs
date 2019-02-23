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

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
