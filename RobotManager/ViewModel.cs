﻿using System;
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

        private RobotModel _SelectedRobot;
        public RobotModel SelectedRobot
        {
            get => _SelectedRobot;
            set => SetProperty(ref _SelectedRobot, value);
        }

        private IList<RobotModel> _Robots;
        public IList<RobotModel> Robots
        {
            get => _Robots;
            set => SetProperty(ref _Robots, value);
        }


        private readonly DelegateCommand _changeNameCommand;
        public ICommand ChangeNameCommand => _changeNameCommand;

        private readonly DelegateCommand _addNewRobotCommand;
        public ICommand AddNewRobotCommand => _addNewRobotCommand;

        public SQLMediator SQLConnection;

        public ViewModel()
        {
            _changeNameCommand = new DelegateCommand(OnChangeName, CanChangeName);
            _addNewRobotCommand = new DelegateCommand(OnAddNewRobot, CanAddNewRobot);



            Robots = new List<RobotModel>();
            Robots.Add(new RobotModel("F10N4", "Transport", 1, 123412));
            Robots.Add(new RobotModel("P3DR0", "Cleaning", 0, 1232333));
            Robots.Add(new RobotModel("1544C", "Warehouse", 3, 9994333));
            SelectedRobot = Robots.ElementAt(0);

            SQLConnection = new SQLMediator();
            if (SQLConnection.Connect())
            {
                SelectedRobot = Robots.ElementAt(2);
                Robots[2] = SQLConnection.GetRobot();
            }
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
            AddRobotWindow addRobotWindow = new AddRobotWindow();
            addRobotWindow.Show();
        }

        private bool CanAddNewRobot(object commandParameter)
        {
            return true;
        }
    }
}
