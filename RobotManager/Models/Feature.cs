using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager.Models
{

    public class Feature : ModelBase
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

        public Feature(string name, int magnitude = 0)
        {
            _Name = name;
            _Magnitude = magnitude;
        }

    }
}
