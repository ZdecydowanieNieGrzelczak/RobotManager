using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotManager
{
    public class ViewModel : ViewModelBase
    {

        private RobotModel _SelectedRobot;
        public RobotModel SelectedRobot
        {
            get => _SelectedRobot;
            set => SetProperty(ref _SelectedRobot, value);
        }

        private ObservableCollection<RobotModel> _Robots;
        public ObservableCollection<RobotModel> Robots
        {
            get => _Robots;
            set => SetProperty(ref _Robots, value);
        }


        private readonly DelegateCommand _changeNameCommand;
        public ICommand ChangeNameCommand => _changeNameCommand;

        private readonly DelegateCommand _addNewRobotCommand;
        public ICommand AddNewRobotCommand => _addNewRobotCommand;

        private readonly DelegateCommand _ModifySelectedRobotCommand;
        public ICommand ModifySelectedRobotCommand => _ModifySelectedRobotCommand;

        private readonly DelegateCommand _CloseWindowCommand;
        public ICommand CloseWindowCommand => _CloseWindowCommand;

        private readonly DelegateCommand _DeleteSelectedRobotCommand;
        public ICommand DeleteSelectedRobotCommand => _DeleteSelectedRobotCommand;

        public SQLMediator SQLConnection;

        public ViewModel()
        {
            _changeNameCommand = new DelegateCommand(OnChangeName, CanChangeName);
            _addNewRobotCommand = new DelegateCommand(OnAddNewRobot, CanAddNewRobot);
            _ModifySelectedRobotCommand = new DelegateCommand(OnModifySelectedRobot, CanModifySelectedRobot);
            _CloseWindowCommand = new DelegateCommand(OnCloseWindowCommand, CanCloseWindow);
            _DeleteSelectedRobotCommand = new DelegateCommand(OnDeleteRobotCommand, CanDeleteRobot);

            SQLConnection = new SQLMediator();
            if (SQLConnection.Connect())
            {
                Robots = SQLConnection.GetRobots();
                SelectedRobot = Robots.ElementAt(0);
            }
            SQLConnection.Close();




    }

        private void OnChangeName(object commandParameter)
        { 
            _changeNameCommand.InvokeCanExecuteChanged();
        }

        private bool CanChangeName(object commandParameter)
        {
            return false;
        }

        private void OnAddNewRobot(object commandParameter)
        {
            AddRobotWindow addRobotWindow = new AddRobotWindow(_Robots);
            addRobotWindow.Show();
        }

        private bool CanAddNewRobot(object commandParameter)
        {
            return true;
        }

        private void OnModifySelectedRobot(object commandParameter)
        {
            int robotIndex = _Robots.IndexOf(_SelectedRobot);
            ModifySelectedRobotWindow modifySelectedRobotWindow = new ModifySelectedRobotWindow(_Robots, robotIndex);
            modifySelectedRobotWindow.Show();
        }

        private bool CanModifySelectedRobot(object commandParameter)
        {
            return true;
        }


        private bool CanCloseWindow(object commandParameter)
        {
            return true;
        }

        private void OnCloseWindowCommand(object commandParameter)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnDeleteRobotCommand(object commandParameter)
        {
            if(_SelectedRobot == null)
            {
                return;
            }
            SQLConnection.Connect();
            SQLConnection.DeleteRobot(_SelectedRobot.Name);
            SQLConnection.Close();
            _Robots.Remove(_SelectedRobot);
            _SelectedRobot = null;
            
        }

        private bool CanDeleteRobot(object commandParameter)
        {
            return _SelectedRobot != null;
        }


    }
}
