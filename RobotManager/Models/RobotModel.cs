using RobotManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RobotManager
{
    public class RobotModel : ModelBase
    {
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

        private List<string> _GroupsList;
        public List<string> GroupsList
        {
            get => _GroupsList;
            set => SetProperty(ref _GroupsList, value);
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
            } else
            {
                _GroupName = "None";
            }         
            _SkillsList = other.SkillsList.ConvertAll(skill => new Skill(skill.Name, (ShouldCopy ? skill.IsPossible : false)));
            _FeaturesList = other.FeaturesList.ConvertAll(feature => new Feature(feature.Name, (ShouldCopy ? feature.Magnitude : 0)));
            _GroupsList = other.GroupsList;
        }


        public RobotModel(string name=null, string groupName="None", int groupID=0, List<string> groups=null)
        {
            _Name = name;
            _GroupName = groupName;
            _GroupID = groupID;
            _GroupsList = groups;

        }


    }
}
