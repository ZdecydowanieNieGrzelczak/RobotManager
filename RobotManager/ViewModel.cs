using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotManager
{
    public class ViewModel : ViewModelBase
    {
        private Robot[] _robots = new Robot[10];
        public Robot[] robots
        {
            get => _robots;
            set => SetProperty(ref _robots, value);
        }


        private string _name;
        public string name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private readonly DelegateCommand _changeNameCommand;
        public ICommand ChangeNameCommand => _changeNameCommand;


        public ViewModel()
        {
            _changeNameCommand = new DelegateCommand(OnChangeName, CanChangeName);


        }

        private void OnChangeName(object commandParameter)
        {
            name = "W4lt3r";
            _changeNameCommand.InvokeCanExecuteChanged();
        }

        private bool CanChangeName(object commandParameter)
        {
            return name != "W4lt3r";
        }
    }
}
