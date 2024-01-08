using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherForecast
{
    public enum Precipitation
    {
        Sunny,
        Cloudy,
        Rainy,
        Snowy
    }
    public class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        public static readonly DependencyProperty TempProperty;
        private string windDirection;
        private int windSpeed;
        

        public WeatherControl (string windDirection, int windSpeed, Precipitation precipitation)
        {
            this.windDirection = windDirection;
            this.windSpeed = windSpeed;
            this.precipitation = precipitation;
        }

        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }
        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsArrange |
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(VaildTemp));
        }



        private static bool VaildTemp(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
                return false;
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
            {
                return t;
            }
            else
                return 0;
        }

    }
}
