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
        public string name { set; get; }

        private string _groupName;
        public string groupName { set; get; }

        private string _color;
        public string color;

        public Robot(string newName, string newGroupName, string newColor)
        {
            _name = newName;
            _groupName = newGroupName;
            _color = newColor;
        }

    }
}
