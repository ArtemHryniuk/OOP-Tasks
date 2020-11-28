using System;

namespace Task_8
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            MyComplex A = new MyComplex(1, 1);
            MyComplex B = new MyComplex();
            MyComplex C = new MyComplex(1);
            MyComplex D = new MyComplex();

            Console.WriteLine("Комплексне число B:");
            B.InputFromTerminal();
            Console.WriteLine($"Re(B) = {B["realValue"]}, Im(B) = {B["imageValue"]}");

            Console.WriteLine("Комплексне число D:");
            D.InputFromTerminal();
            Console.WriteLine($"Re(D) = {D["realValue"]}, Im(D) = {D["imageValue"]}");

            Console.WriteLine($"\nA = {A}, B = {B}, C = {C}, D = {D}");
            C = A + B;
            Console.WriteLine($"C = A + B = {A} + {B} = {C}");
            C = A + 10.5;
            Console.WriteLine($"C = A + 10.5 = {A} + 10.5 = {C}");
            C = 10.5 + A;
            Console.WriteLine($"C = 10.5 + A = 10.5 + {A} = {C}");
            D = -C;
            Console.WriteLine($"D = -C = -({C}) = {D}");
            Console.Write($"C = A + B + C + D = {A} + {B} + {C} + ({D}) = ");
            C = A + B + C + D;
            Console.WriteLine(C);
            C = A = B = C;
            Console.WriteLine($"C = A = B = C = {C}");
        }
    }
}