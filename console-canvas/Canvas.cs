using System;
using System.Collections.Generic;
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
            _drawables.ForEach(x => x.Update()); // For looping on an array is 5x 'cheaper' than List.ForEach. change it later? //https://stackoverflow.com/a/365658/2435006
        }

        private void DrawDrawables()
        {
            Console.Clear();
            _drawables.ForEach(x => x.Draw());
        }

        private void AddNewDrawables()
        {
            while (_newDrawables.TryDequeue(out var drawable))
                _drawables.Add(drawable);
        }

    }
}
