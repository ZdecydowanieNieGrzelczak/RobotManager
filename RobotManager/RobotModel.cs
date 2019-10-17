using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager
{
    class RobotModel
    {
        private string _Name;
        public string Name { get; set; }

        private string _GroupName;
        public string GroupName { get; set; }

        private List<Tuple<string, int>> _FeaturesList;
        public List<Tuple<string, int>> FeaturesList;

        private List<Tuple<string, Boolean>> _SkillsList;
        public List<Tuple<string, Boolean>> SkillsList;


        public RobotModel(string newName, string newGroup, List<Tuple<string, int>> newFeaturesList, List<Tuple<string, Boolean>> newSkillsList)
        {
            _Name = newName;
            _GroupName = newGroup;
            _FeaturesList = newFeaturesList;
            _SkillsList = newSkillsList;
        }



    }
}
