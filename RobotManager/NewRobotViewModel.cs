using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace RobotManager
{
    class NewRobotViewModel : ViewModelBase
    {

        private string[] _groups;
        public string[] groups
        {
            get => _groups;
            set => SetProperty(ref _groups, value);
        }

        private RobotModel _NewRobot;
        public RobotModel NewRobot
        {
            get => _NewRobot;
            set => SetProperty(ref _NewRobot, value);
        }


        private string[] _Names;
        public string[] Names { get; set; }

        private readonly DelegateCommand _AddNewRobotCommand;
        public ICommand AddNewRobotCommand => _AddNewRobotCommand;


        public NewRobotViewModel()
        {
            _AddNewRobotCommand = new DelegateCommand(OnAddNewRobot, CanAddRobot);
            groups = new string[] { "None", "Cleaning department", "Warehouse", "Transport robot", "Packing robot" };
        }

        private bool CanAddRobot(object commandParameter)
        {
            if(NewRobot.Name == null)
            {
                return false;
            }
            return true;
        }

        private void OnAddNewRobot(object commandParameter)
        {

        }


    }



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

    public class NegateBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }

}