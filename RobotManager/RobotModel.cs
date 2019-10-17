﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager
{
    class RobotModel : INotifyPropertyChanged
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


        private string[] mock_features = new string[] { "Movement Speed", "Capacity", "Precision", "Battery Capacity", "Power Consumption" };
        private string[] mock_skills = new string[] { "Dusting", "Wet Cleaning", "Window Cleaning", "Packing", "Grabbing Objects", "Carrying Objects",
                "Skanning barcodes", "Pathfinding", "Emptying Garbage", "Requesting Restocking" };




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
        public string GroupName { get; set; }

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


        public RobotModel()
        {
            _Name = null;
            _GroupName = null;
            _GroupID = 0;

            _FeaturesList = new List<Feature>();
            _SkillsList = new List<Skill>();

            foreach (string mock_feat in mock_features)
            {
                FeaturesList.Add(new Feature(mock_feat,0));
            }
            foreach (string mock_skill in mock_skills)
            {
                SkillsList.Add(new Skill(mock_skill, true));
            }
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

        public Feature(string name, int magnitude)
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

        public bool IsNotPossible
        {
            get => !_IsPossible;
            set => value = !_IsPossible;
        }

        public Skill(string name, bool isPossible)
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
