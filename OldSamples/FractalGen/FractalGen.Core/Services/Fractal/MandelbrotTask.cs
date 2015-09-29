using System;
using System.Threading;

namespace FractalGen.Core.Services.Fractal
{
    public class MandelbrotTask : IMandelbrotTask
    {
        private readonly Action<ISimpleWriteableBitmap> _callback;

        public MandelbrotTask(IMandelbrot mandelbrot, Action<ISimpleWriteableBitmap> callback)
        {
            Mandelbrot = mandelbrot;
            _callback = callback;
        }

        public IMandelbrot Mandelbrot { get; private set; }
        public bool CancelFlag { get; private set; }
        public bool CopyFlag { get; private set; }

        public void Cancel()
        {
            CancelFlag = true;
        }

        public void RequestCopy()
        {
            CopyFlag = true;
        }

        public void CopyComplete(ISimpleWriteableBitmap bitmap)
        {
            CopyFlag = false;
            if (CancelFlag)
                return;
            _callback(bitmap);
        }

        public void ProcessAsync()
        {
            ThreadPool.QueueUserWorkItem(ignored => ProcessMandelbrot(this));
        }

        private void ProcessMandelbrot(MandelbrotTask task)
        {
            // work in chunks of 20 - why 20? No good reason - sorry.
            for (int i = 0; i < 20; i++)
            {
                if (task.Mandelbrot.IsScaleComplete)
                {
                    var final = task.Mandelbrot.Bitmap.Clone();
                    task.CopyComplete(final);
                    return;
                }

                if (task.CancelFlag)
                    return;

                if (task.CopyFlag)
                {
                    var bitmap = task.Mandelbrot.Bitmap.Clone();
                    task.CopyComplete(bitmap);
                }

                task.Mandelbrot.NextLine();
            }

            ProcessAsync();
        }
    }
}