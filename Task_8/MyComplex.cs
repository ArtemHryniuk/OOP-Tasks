using System;

namespace Task_8
{
    public class MyComplex
    {
        private double Re, Im;

        public MyComplex(double InitRe = 0, double InitIm = 0)
        {
            Re = InitRe;
            Im = InitIm;
        }

        public void InputRe()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введіть дійсну частину: ");
                    Re = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введіть число!\nСпробуйте ще раз\n");
                }
            }
        }

        public void InputIm()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введіть уявну частину: ");
                    Im = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введіть число!\nСпробуйте ще раз\n");
                }
            }
        }

        public void InputFromTerminal()
        {
            InputRe();
            InputIm();
        }

        public double this[string key]
        {
            get => key switch
            {
                "realValue" => Re,
                "imageValue" => Im,
                _ => 0,
            };
            set
            {
                switch (key)
                {
                    case "realValue":
                        Re = value;
                        break;
                    case "imageValue":
                        Im = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public override string ToString()
        {
            if (Im == 0)
            {
                return Re.ToString();
            }
            else
            {
                if (Re == 0)
                {
                    return $"{Im}*i";
                }
                else
                {
                    if (Im >= 0)
                    {
                        return $"{Re} + {Im}*i";
                    }
                    else
                    {
                        return $"{Re} - {Math.Abs(Im)}*i";
                    }
                }
            }
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re + b.Re, a.Im + b.Im);
        }

        public static MyComplex operator +(MyComplex a, double b)
        {
            return new MyComplex(a.Re + b, a.Im);
        }

        public static MyComplex operator +(double a, MyComplex b)
        {
            return new MyComplex(a + b.Re, b.Im);
        }

        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re - b.Re, a.Im - b.Im);
        }

        public static MyComplex operator -(MyComplex a, double b)
        {
            return new MyComplex(a.Re - b, a.Im);
        }

        public static MyComplex operator -(double a, MyComplex b)
        {
            return new MyComplex(a - b.Re, -b.Im);
        }

        public static MyComplex operator -(MyComplex a)
        {
            return new MyComplex(-a.Re, -a.Im);
        }

        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re + b.Re, a.Im + b.Im);
        }
    }
}