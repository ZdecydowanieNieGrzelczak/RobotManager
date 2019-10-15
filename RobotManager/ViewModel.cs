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
        private Robot[] _robots;
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

        private readonly DelegateCommand _addNewRobotCommand;
        public ICommand AddNewRobotCommand => _addNewRobotCommand;
        


        public ViewModel()
        {
            _changeNameCommand = new DelegateCommand(OnChangeName, CanChangeName);
            _addNewRobotCommand = new DelegateCommand(OnAddNewRobot, CanAddNewRobot);
            robots = new Robot[3];
            robots[0] = new Robot("F10N4", "Transport", "red");
            robots[1] = new Robot("P3DR0", "Cleaning", "blue");
            robots[2] = new Robot("1544C", "Warehouse", "pink");

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

        private void OnAddNewRobot(object commandParameter)
        {
            AddRobotWindow addRobotWindow = new AddRobotWindow();
            addRobotWindow.Show();
        }

        private bool CanAddNewRobot(object commandParameter)
        {
            return true;
        }
    }
}
