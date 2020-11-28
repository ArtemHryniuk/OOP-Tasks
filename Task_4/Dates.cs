using System;
using System.IO;

namespace Task_4
{
    public class Dates
    {
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            private set
            {
                date = value;
            }
        }

        public Dates() { }

        public Dates(int y, int m, int d)
        {
            try
            {
                Date = new DateTime(y, m, d);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Не вдалось виконати програму.\nНевірна дата");
                Environment.Exit(0);
            }
        }

        public ConsoleKey GetUserChoice()
        {
            Console.WriteLine("Оберіть тип введення:\n1. З клавіатури\n2. З файлу");
            return Console.ReadKey().Key;
        }

        public void DataInput(string path)
        {
            bool flag = false;
            while (flag == false)
            {
                switch (GetUserChoice())
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            Console.WriteLine("Ви обрали з клавіатури");
                            using StreamWriter sw = new StreamWriter(path);
                            Console.Write("Введіть першу дату у форматі yyyy.MM.dd: ");
                            int[] array1 = DateTransformation(Console.ReadLine());
                            sw.WriteLine(string.Join(".", array1));
                            Console.Write("Введіть другу дату у форматі yyyy.MM.dd: ");
                            int[] array2 = DateTransformation(Console.ReadLine());
                            sw.WriteLine(string.Join(".", array2));
                            Console.Clear();
                            ArrayOperations(array1, array2);
                            flag = true;
                        }
                        break;
                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            Console.WriteLine("Ви обрали з файлу");
                            if (File.Exists(path) == false)
                            {
                                Console.WriteLine($"Файл {Path.GetFileName(path)} не найден!"
                                    + $"\nСтворіть файл по шляху {Path.GetFullPath(path)}");
                                return;
                            }
                            else if (new FileInfo(path).Length == 0)
                            {
                                Console.WriteLine($"Не вдалось виконати програму."
                                    + $"\nФайл {Path.GetFileName(path)} пустий");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Дані у файлі введено вірно!");
                            }
                            using StreamReader sr = new StreamReader(path);
                            int[] array1 = DateTransformation(sr.ReadLine());
                            int[] array2 = DateTransformation(sr.ReadLine());
                            ArrayOperations(array1, array2);
                            flag = true;
                        }
                        break;
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Оберіть з двох варіантів!\nСпробуйте ще раз\n");
                        }
                        break;
                }
            }
        }

        public int[] DateTransformation(string text)
        {
            int[] elements = new int[3];
            for (int i = 0; i < text.Split(".").Length; i++)
            {
                try
                {
                    elements[i] = Convert.ToInt32(text.Split(".")[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не вдалось виконати програму.\n{ex.Message}");
                    Environment.Exit(0);
                }
            }
            return elements;
        }

        public double ConvertDateToDays(DateTime dateValue)
        {
            return dateValue.Day + (30.417 * dateValue.Month) + (365 * dateValue.Year);
        }

        public string ConvertDaysToDate(double days)
        {
            return new DateTime(DateDifference(days)[0],
                                DateDifference(days)[1],
                                DateDifference(days)[2]).ToString("yyyy.MM.dd");
        }

        private int[] DateDifference(double days)
        {
            double result = (int)days;
            int year = (int)((days - 30.417) / 365);
            result -= year * 365;
            int month = (int)(result / 30.417);
            result -= month * 30.417;
            int day = (int)(result + 1);
            return new int[] { year, month, day };
        }

        private static double DifferenceOfTwoDates(double getDateToDays1, double getDateToDays2)
        {
            return getDateToDays1 - getDateToDays2;
        }

        private static double SumOfTwoDates(double getDateToDays1, double getDateToDays2)
        {
            return getDateToDays1 + getDateToDays2;
        }

        public void ArrayOperations(int[] array1, int[] array2)
        {
            Dates date1 = new Dates(array1[0], array1[1], array1[2]);
            Dates date2 = new Dates(array2[0], array2[1], array2[2]);

            DateTime getDate1 = date1.Date;
            DateTime getDate2 = date2.Date;

            double getDateToDays1 = date1.ConvertDateToDays(getDate1);
            double getDateToDays2 = date2.ConvertDateToDays(getDate2);

            Console.WriteLine($"Перша дата у форматі yyyy.MM.dd: {getDate1:yyyy.MM.dd}"
                + $"\nДруга дата у форматі yyyy.MM.dd: {getDate2:yyyy.MM.dd}"
                + $"\nРізниця двох дат: {DifferenceOfTwoDates(getDateToDays1, getDateToDays2):f0} днів"
                + $"\nСума двох дат: {SumOfTwoDates(getDateToDays1, getDateToDays2):f0} днів"
                + $"\nКонвертація першої дати в дні: {getDateToDays1:f0}"
                + $"\nКонвертація назад в дату: {date1.ConvertDaysToDate(getDateToDays1)}"
                + $"\nКонвертація другої дати в дні: {getDateToDays2:f0}"
                + $"\nКонвертація назад в дату: {date2.ConvertDaysToDate(getDateToDays2)}");
        }
    }
}