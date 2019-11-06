using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager.Models
{
    public class Skill : ModelBase
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


        public Skill(string name, bool isPossible = false)
        {
            _Name = name;
            _IsPossible = isPossible;
        }

    }
}
