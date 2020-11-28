using System;
using System.Linq;

namespace Task_7
{
    internal class WeatherParametersDay
    {
        public double AverageTemperatureDay { get; private set; }

        public double AverageTemperatureNight { get; private set; }

        public double AverageAtmosphericPressure { get; private set; }

        public double Precipitation { get; private set; }

        public TypeOfWeather TypeOfWeather { get; private set; }

        public WeatherParametersDay(double averageTemperatureDay,
                                    double averageTemperatureNight,
                                    double averageAtmosphericPressure,
                                    double precipitation,
                                    int typeOfWeather)
        {
            if (precipitation >= 0
                && averageAtmosphericPressure >= 0
                && Enumerable.Range(0, 7).Contains(typeOfWeather))
            {
                AverageTemperatureDay = averageTemperatureDay;
                AverageTemperatureNight = averageTemperatureNight;
                AverageAtmosphericPressure = averageAtmosphericPressure;
                Precipitation = precipitation;
                TypeOfWeather = (TypeOfWeather)typeOfWeather;
            }
        }
    }
}