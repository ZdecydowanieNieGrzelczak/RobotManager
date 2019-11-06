using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RobotManager.Converters
{

    public class MagnitudeToFeatureNameConverter : IValueConverter
    {
        public string[] featureSymbols = new string[] { "None", "Very low", "Low", "Medium", "High", "Very high" };

        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return featureSymbols[(int)value];
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Array.IndexOf(featureSymbols, value);
        }
    }
    
}
