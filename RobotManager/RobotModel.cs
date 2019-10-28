using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager
{
    public class RobotModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }


        //private string[] mock_features = new string[] { "Movement Speed", "Capacity", "Precision", "Battery Capacity", "Power Consumption" };
        //private string[] mock_skills = new string[] { "Dusting", "Wet Cleaning", "Window Cleaning", "Packing", "Grabbing Objects", "Carrying Objects",
        //        "Skanning barcodes", "Pathfinding", "Emptying Garbage", "Requesting Restocking" };




        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        private int _GroupID;
        public int GroupID
        {
            get => _GroupID;
            set => SetProperty(ref _GroupID, value);
        }

        private string _GroupName;
        public string GroupName
        {
            get => _GroupName;
            set => SetProperty(ref _GroupName, value);
        }

        private List<Feature> _FeaturesList;
        public List<Feature> FeaturesList
        {
            get => _FeaturesList;
            set => SetProperty(ref _FeaturesList, value);
        }

        private List<Skill> _SkillsList;
        public List<Skill> SkillsList
        {
            get => _SkillsList;
            set => SetProperty(ref _SkillsList, value);
        }


        public RobotModel(string name, string groupName, int groupID, List<Skill> skillsList, List<Feature> featuresList)
        {
            _Name = name;
            _GroupName = groupName;
            _GroupID = groupID;
            _SkillsList = new List<Skill>(skillsList);
            _FeaturesList = new List<Feature>(featuresList);

        }

        public RobotModel(RobotModel other, Boolean ShouldCopy)
        {
            if (ShouldCopy)
            {
                _Name = other.Name;
                _GroupID = other.GroupID;
                _GroupName = other.GroupName;
            }         
            _SkillsList = other.SkillsList.ConvertAll(skill => new Skill(skill.Name, (ShouldCopy ? skill.IsPossible : false)));
            _FeaturesList = other.FeaturesList.ConvertAll(feature => new Feature(feature.Name, (ShouldCopy ? feature.Magnitude : 0)));
        }


        public RobotModel(string name=null, string groupName=null, int groupID=0)
        {
            _Name = name;
            _GroupName = groupName;
            _GroupID = groupID;

        }


    }


    public class Feature : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        private int _Magnitude;
        public int Magnitude
        {
            get => _Magnitude;
            set => SetProperty(ref _Magnitude, value);
        }

        public Feature(string name, int magnitude=0)
        {
            _Name = name;
            _Magnitude = magnitude;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }


    }

    public class Skill : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        private bool _IsPossible;
        public bool IsPossible
        {
            get => _IsPossible;
            set => SetProperty(ref _IsPossible, value);
        }


        public Skill(string name, bool isPossible=false)
        {
            _Name = name;
            _IsPossible = isPossible;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }




}
