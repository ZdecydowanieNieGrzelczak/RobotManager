﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RobotManager
{
    class AddRobotViewModel : ViewModelBase
    {

        private bool _RobotNamesError;
        public bool RobotNamesError
        {
            get => _RobotNamesError;
            set => SetProperty(ref _RobotNamesError, value);
        }

        public Action CloseAction { get; set; }

        private SQLMediator _SQLConnection;

        private string[] _groups;
        public string[] groups
        {
            get => _groups;
            set => SetProperty(ref _groups, value);
        }

        private RobotModel _NewRobot;
        public RobotModel NewRobot
        {
            get => _NewRobot;
            set => SetProperty(ref _NewRobot, value);
        }

        private ObservableCollection<RobotModel> _Robots;


        //private string[] _Names;
        //public string[] Names { get; set; }

        private readonly DelegateCommand _AddNewRobotCommand;
        public ICommand AddNewRobotCommand => _AddNewRobotCommand;

        private readonly DelegateCommand _SelectGroupCommand;
        public ICommand SelectGroupCommand => _SelectGroupCommand;


        public AddRobotViewModel(ObservableCollection<RobotModel> robots)
        {
            _AddNewRobotCommand = new DelegateCommand(OnAddNewRobot, CanAddRobot);
            _SelectGroupCommand = new DelegateCommand(OnSelectGroup, CanSelectGroup);
            _SQLConnection = new SQLMediator();
            _NewRobot = new RobotModel(robots[0], false);
            _Robots = robots;
            _RobotNamesError = false;
        }

        private bool CanAddRobot(object commandParameter)
        {
            return true;
        }

        private void OnAddNewRobot(object commandParameter)
        {
            foreach (RobotModel robot in _Robots)
            {
                if (robot.Name == NewRobot.Name)
                {
                    MessageBox.Show("Cannot add robot with duplicate name!", "Invalid name");
                    return;
                }
            }
            _NewRobot.GroupID = _NewRobot.GroupsList.IndexOf(_NewRobot.GroupName);
            if (_SQLConnection.Connect())
            {
                _SQLConnection.ModifyOrAddRobot(_NewRobot, "dbo.AddNewRobot");
                _SQLConnection.Close();
                _Robots.Add(_NewRobot);
                MessageBox.Show("Robot added!");


            }
            else
            {
                MessageBox.Show("Cannot connect to database!", "Database error");
            }
            CloseAction();

        }

        private bool CanSelectGroup(object commandParameter)
        {
            return true;
        }

        private void OnSelectGroup(object commandParameter)
        {
            
        }

    }

}