using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager
{
    public class Robot
    {
        private string _name;
        public string name
        {
            get => _name;
        }


        private string _groupName;
        public string GroupName {
            set
            {
                GroupName = value;
            }
            get => _groupName;
        }

        private string _color;
        public string color
        {
            set
            {
                color = value;
            }
            get => _color;
        }

        public Robot(string newName, string newGroupName, string newColor)
        {
            _name = newName;
            _groupName = newGroupName;
            _color = newColor;
        }

    }
}
