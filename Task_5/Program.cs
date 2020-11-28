using System;
using System.IO;

namespace Task_5
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            WorkingWithArrays myArrays = new WorkingWithArrays();

            string pathX = @"../../../x.txt";
            string pathY = @"../../../y.txt";
            string pathZ = @"../../../z.txt";

            if (File.Exists(pathX) == false)
            {
                Console.WriteLine($"Файл {Path.GetFileName(pathX)} не найден!"
                    + $"\nСтворіть файл по шляху {Path.GetFullPath(pathX)}");
                return;
            }
            else if (new FileInfo(pathX).Length == 0)
            {
                Console.WriteLine($"Не вдалось виконати програму."
                    + $"\nФайл {Path.GetFileName(pathX)} пустий."
                    + $"\nВвведіть одновимірний масив у файл {Path.GetFileName(pathX)} "
                    + $"та перезапустіть програму.");
                return;
            }
            else if (File.Exists(pathY) == false)
            {
                Console.WriteLine($"Файл {Path.GetFileName(pathY)} не найден!"
                    + $"\nСтворіть файл по шляху {Path.GetFullPath(pathY)}");
                return;
            }
            else if (new FileInfo(pathY).Length == 0)
            {
                Console.WriteLine($"Не вдалось виконати програму."
                    + $"\nФайл {Path.GetFileName(pathY)} пустий."
                    + $"\nВвведіть одновимірний масив у файл {Path.GetFileName(pathY)} "
                    + $"та перезапустіть програму.");
            }
            else if (myArrays.ArrayTransformation(pathX).Length != myArrays.ArrayTransformation(pathY).Length)
            {
                Console.WriteLine($"Не вдалось виконати програму."
                    + $"\nРізна кількість елементів у масивах."
                    + $"\nВнесіть зміни та перезапустіть програму.");
                return;
            }
            else
            {
                Console.WriteLine("Дані у файлах введено вірно!");
            }

            double[] x = myArrays.ArrayTransformation(pathX);
            double[] y = myArrays.ArrayTransformation(pathY);
            double[] z = new double[x.Length];

            myArrays.NegativeElementsToTheSquare(ref x);
            myArrays.TheSumOfTheElements(x, y, ref z);

            File.WriteAllText(pathZ, string.Join(", ", z));
            Console.WriteLine($"У файл {Path.GetFileName(pathZ)} було записано: {string.Join(", ", z)}");
        }
    }
}