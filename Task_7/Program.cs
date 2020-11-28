using System;
using System.IO;
using System.Linq;

namespace Task_7
{
    internal class Program
    {
        private static ConsoleKey GetUserChoice()
        {
            Console.WriteLine("Оберіть тип введення:\n1. З клавіатури\n2. З файлу");
            return Console.ReadKey().Key;
        }

        private static double[][] SwitchChoice(string path)
        {
            string[] lines = new string[30];
            bool flag = false;
            while (flag == false)
            {
                switch (GetUserChoice())
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Ви обрали з консолі");
                        EnterDataFromKeyboard(out lines);
                        flag = true;
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Ви обрали з файлу");
                        if (File.Exists(path) == false)
                        {
                            Console.WriteLine($"Файл {Path.GetFileName(path)} не найден!"
                                + $"\nСтворіть файл по шляху {Path.GetFullPath(path)}");
                            Environment.Exit(0);
                        }
                        else if (new FileInfo(path).Length == 0)
                        {
                            Console.WriteLine($"Не вдалось виконати програму."
                                + $"\nФайл {Path.GetFileName(path)} пустий");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Дані у файлі введено вірно!");
                        }
                        lines = File.ReadAllLines(path);
                        flag = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Оберіть з двох варіантів!\nСпробуйте ще раз\n");
                        break;
                }
            }
            return StringToDoubleArray(lines);
        }

        private static void EnterDataFromKeyboard(out string[] lines)
        {
            Console.WriteLine(@"Для кожного дня введіть дані в окремому рядку у форматі: 1 2 3 4 5
1 – середня температура вдень
2 – середня температура вночі
3 – середній атмосферний тиск
4 – кількість опадів (мм/день)
5 – тип погоди за день
Не визначено – 0, Дощ – 1, Короткочасний дощ – 2, Гроза – 3, Сніг – 4, Туман – 5, Похмуро – 6, Сонячно – 7");
            lines = new string[30];
            for (int j = 0; j < 30; j++)
            {
                while (true)
                {
                    Console.Write($"День №{j + 1}: ");
                    lines[j] = Console.ReadLine();
                    try
                    {
                        if (lines[j].Equals("") == false)
                        {
                            if (lines[j].Any(c => char.IsLetter(c)))
                            {
                                throw new FormatException();
                            }
                        }
                        else
                        {
                            throw new NullReferenceException();
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static double[][] StringToDoubleArray(string[] lines)
        {
            double[][] data = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] linesSplit = lines[i].Split();
                data[i] = linesSplit.Length == 4 ? (new double[linesSplit.Length + 1]) : (new double[linesSplit.Length]);
                for (int j = 0; j < linesSplit.Length; j++)
                {
                    double numbers = 0;
                    try
                    {
                        numbers = Convert.ToDouble(linesSplit[j]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Не вдалось виконати програму.\n{ex.Message}");
                        Environment.Exit(0);
                    }
                    data[i][j] = numbers;
                }
            }
            return data;
        }

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string path = @"../../../data.txt";
            double[][] data = SwitchChoice(path);
            WeatherParametersDay[] weatherParametersDays = new WeatherParametersDay[data.Length];
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    weatherParametersDays[i] = new WeatherParametersDay(data[i][0],
                                                                        data[i][1],
                                                                        data[i][2],
                                                                        data[i][3],
                                                                        (int)data[i][4]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не вдалось виконати програму.\n{ex.Message}");
                Environment.Exit(0);
            }
            WeatherDays weatherDays = new WeatherDays(weatherParametersDays);
            Console.Clear();
            Console.WriteLine($"Кількість туманних днів: {weatherDays.CountFogDays()}"
                + $"\nКількість днів, коли був дощ або гроза: {weatherDays.CountRainOrThunderstormDays()}"
                + $"\nСередній атмосферний тиск за місяць: {weatherDays.AveragePressure():f0}");
        }
    }
}