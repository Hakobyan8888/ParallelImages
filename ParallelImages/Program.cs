using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ParallelImages
{
    class Program
    {
        static void Main(string[] args)
        {
            AppSettings appSettings = new AppSettings();
            string[] files = Directory.GetFiles(appSettings.FilePathFirst, "*.jpg");
            string newDir = appSettings.FilePathSecond;
            Directory.CreateDirectory(newDir);

            Parallel.ForEach(files, (currentFile) =>
            {
                string filename = Path.GetFileName(currentFile);
                Bitmap bitmap = new Bitmap(currentFile);
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                bitmap.Save(Path.Combine(newDir, filename));
                
                Console.WriteLine($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}");
            });

        }
    }
}
