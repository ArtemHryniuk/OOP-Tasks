using System;

namespace Task_3
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int a;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введіть змінну типу int");
                    a = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Невірно введений тип!\nСпробуйте ще раз\n");
                }
            }

            double b;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введіть змінну типу double");
                    b = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Невірно введений тип!\nСпробуйте ще раз\n");
                }
            }

            long c;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введіть змінну типу long");
                    c = Convert.ToInt64(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Невірно введений тип!\nСпробуйте ще раз\n");
                }
            }
            Console.WriteLine($"a = {a}; b = {b}; c = {c}");
        }
    }
}