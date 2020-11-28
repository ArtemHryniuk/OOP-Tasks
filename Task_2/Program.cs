using System;

namespace Task_2
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Console.WriteLine("Введіть змінну типу int");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введiть змiнну типу double");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введіть змінну типу long");
                long c = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine($"a = {a}; b = {b}; c = {c}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невірно введений тип!");
            }
        }
    }
}