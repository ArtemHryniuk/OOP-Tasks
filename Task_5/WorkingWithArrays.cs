using System;
using System.IO;

namespace Task_5
{
    public class WorkingWithArrays
    {
        public WorkingWithArrays() { }

        public double[] ArrayTransformation(string text)
        {
            double[] array = new double[File.ReadAllText(text).Split(", ").Length];
            for (int i = 0; i < File.ReadAllText(text).Split(", ").Length; i++)
            {
                try
                {
                    array[i] = Convert.ToDouble(File.ReadAllText(text).Split(", ")[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не вдалось виконати програму.\n{ex.Message}"
                        + $"\nВнесіть зміни та перезапустіть.");
                    Environment.Exit(0);
                }
            }
            return array;
        }

        public void NegativeElementsToTheSquare(ref double[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = x[i] >= 0 ? x[i] : x[i] * x[i];
            }
        }

        public void TheSumOfTheElements(double[] x, double[] y, ref double[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = x[i] + y[i];
            }
        }
    }
}