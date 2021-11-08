using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLab6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public enum Rainfall
        {
            Sunny = 0,
            Cloudly = 1,
            Rain = 2,
            Snow = 3
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemperature)));
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int temp = (int)baseValue;
            if (temp >=-50 && temp <=50)
            {
                return temp;
            }
            else
            {
                return 0;
            }
        }
    }
}
