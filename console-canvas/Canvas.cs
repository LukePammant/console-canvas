using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleCanvas
{
	public class Canvas
	{
		public event Action OnRender;
		public int Height;
		public int Width;
		public int FramesPerSecond = 30;

		private List<IDrawable> _drawables;
		private Queue<IDrawable> _newDrawables;

		public Canvas()
		{
			_drawables = new List<IDrawable>();
			_newDrawables = new Queue<IDrawable>();

			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.CursorVisible = false;
            Console.SetBufferSize(120, 30);

            Height = Console.BufferHeight;
			Width = Console.BufferWidth;

            Task.Run(RenderLoop);
		}

		public void AddDrawable(IDrawable item)
		{
			_newDrawables.Enqueue(item);
		}

		public async Task RenderLoop()
		{
			while (Program.IsGameRunning)
            {
                OnRender?.Invoke();

                AddNewDrawables();
                UpdateDrawables();
                DrawDrawables();

                await Task.Delay(1000 / FramesPerSecond);
            }
        }

        private void UpdateDrawables()
        {
            _drawables.ForEach(x => x.Update());
            //foreach (var drawable in _drawables)
            //{
            //    drawable.Update();
            //}
        }

        private void DrawDrawables()
        {
            Console.Clear();
            var s = Stopwatch.StartNew();
            _drawables.ForEach(x => x.Draw());
            s.Stop();
            var ss = s.ElapsedMilliseconds;
            //foreach (var drawable in _drawables)
            //{
            //    drawable.Draw();
            //}
        }

        private void AddNewDrawables()
        {
            while (_newDrawables.TryDequeue(out var drawable))
                _drawables.Add(drawable);
        }
    }
}
