using System;

namespace Task_4
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string path = @"../../../dates.txt";
            Dates dates = new Dates();
            dates.DataInput(path);
        }
    }
}