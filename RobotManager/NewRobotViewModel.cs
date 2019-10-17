using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RobotManager
{
    class NewRobotViewModel : ViewModelBase
    {
        private string _name;
        public string name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string[] _groups;
        public string[] groups
        {
            get => _groups;
            set => SetProperty(ref _groups, value);
        }

        private List<Feature> _featuresList = new List<Feature>();
        public List<Feature> featuresList
        {
            get => _featuresList;
            set => SetProperty(ref _featuresList, value);
        }


        private string[] mock_features = new string[] { "Movement Speed", "Capacity", "Precision", "Battery Capacity", "Power Consumption" };
        private string[] mock_skills = new string[] { "Dusting", "Wet Cleaning", "Window Cleaning", "Packing", "Grabbing Objects", "Carrying Objects",
                "Skanning barcodes", "Pathfinding", "Emptying Garbage", "Requesting Restocking" };


    private List<Skill> _skillsList = new List<Skill>();
        public List<Skill> skillsList
        {
            get => _skillsList;
            set => SetProperty(ref _skillsList, value);
        }


        public NewRobotViewModel()
        {
            groups = new string[] { "None", "Cleaning department", "Warehouse", "Transport robot", "Packing robot" };
            foreach(string mock_feat in mock_features)
            {
                featuresList.Add(new Feature() { featureName = mock_feat, magnitude = 0 });
            }
            foreach(string mock_skill in mock_skills)
            {
                skillsList.Add(new Skill() { skillName = mock_skill, canPerform = false });
            }
        }
    }

    public class Feature
    {
        public string featureName { get; set; }
        public int magnitude { get; set; }


        public static string magnitudeToValueName(int magnitude)
        {
            string[] featureSymbols = new string[] { "None", "Very low", "Low", "Medium", "High", "Very high" };
            return featureSymbols[magnitude];

        }
    }



    public class Skill
    {
        public string skillName { get; set; }
        public Boolean canPerform { get; set; }
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

}