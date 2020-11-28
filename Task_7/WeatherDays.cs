using System;
using System.Linq;

namespace Task_7
{
    internal enum TypeOfWeather
    {
        NotDefined = 0,
        Rain = 1,
        ShortTermRain = 2,
        Thunderstorm = 3,
        Snow = 4,
        Fog = 5,
        Gloomy = 6,
        Sunny = 7
    }

    internal class WeatherDays
    {
        internal WeatherParametersDay[] DataWeatherArray { get; }

        public WeatherDays(WeatherParametersDay[] dataWeatherArray)
        {
            DataWeatherArray = dataWeatherArray;
        }

        public int CountRainOrThunderstormDays()
        {
            return CountDays(TypeOfWeather.Rain, TypeOfWeather.Thunderstorm);
        }

        public int CountFogDays()
        {
            return CountDays(TypeOfWeather.Fog);
        }

        private int CountDays(params TypeOfWeather[] typeOfWeather)
        {
            int count = 0;
            for (int i = 0; i < DataWeatherArray.Length; i++)
            {
                WeatherParametersDay day = DataWeatherArray[i];
                count += typeOfWeather.Contains(day.TypeOfWeather) ? 1 : 0;
            }
            return count;
        }

        public double AveragePressure()
        {
            double SumOfAtmosphericPressure = 0;
            for (int i = 0; i < DataWeatherArray.Length; i++)
            {
                WeatherParametersDay day = DataWeatherArray[i];
                SumOfAtmosphericPressure += day.AverageAtmosphericPressure;
            }
            return SumOfAtmosphericPressure / DataWeatherArray.Length;
        }
    }
}