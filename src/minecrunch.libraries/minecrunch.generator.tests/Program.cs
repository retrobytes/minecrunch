using System;
using System.Drawing;

namespace minecrunch.generator.tests
{
    class MainClass
    {
        const int SIZE = 1024;
        const double STRETCH = 1 / 400.0;
        public static void Main(string[] args)
        {
            var settings = new WorldGenerationSettings();
            var module = new WorldGenerator(settings);
            var rivers = module.CreateModule();

            using (var b = new Bitmap(SIZE, SIZE))
            {
                for (int x = 0; x< SIZE; x++)
                {
                    for (int y = 0; y< SIZE; y++)
                    {
                        double value = rivers.GetValue(x*STRETCH, 0, y*STRETCH);
                        value += 1;
                        value /= 2.0;
                        int blue = (int)((value * -1 + 1) * 255);
                        int green = (int)(value * 255);

                        b.SetPixel(x, y, Color.FromArgb(green, green, green));
                    }
                    if (x % 10 == 0)
                        Console.WriteLine($"Percent Complete: " + (x / (double)SIZE) * 100.0);
                }
                b.Save("test.bmp");
            }
        }
    }
}
