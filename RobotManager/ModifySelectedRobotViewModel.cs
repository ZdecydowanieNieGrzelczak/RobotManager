using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RobotManager
{
    class ModifySelectedRobotViewModel : ViewModelBase
    {

        public SQLMediator SQLConnection;


        public Action CloseAction { get; set; }

        private bool _IsDirty;
        public bool IsDirty
        {
            get => _IsDirty;
            set => SetProperty(ref _IsDirty, value);
        }

        private RobotModel _BackupModel;
        public RobotModel BackupModel
        {
            get => _BackupModel;
            set => SetProperty(ref _BackupModel, value);
        }

        private RobotModel _SelectedModel;
        public RobotModel SelectedModel
        {
            get => _SelectedModel;
            set
            {
                SetProperty(ref _SelectedModel, value);
                SetProperty(ref _IsDirty, true);
            }
        }

        private readonly DelegateCommand _ExitCommand;
        public ICommand ExitCommand => _ExitCommand;

        private readonly DelegateCommand _SaveRobotCommand;
        public ICommand SaveRobotCommand => _SaveRobotCommand;

        private readonly DelegateCommand _ValuesUpdatedCommand;
        public ICommand ValuesUpdatedCommand => _ValuesUpdatedCommand;



        public ModifySelectedRobotViewModel()
        {
            _ExitCommand = new DelegateCommand(OnExitCommand, CanExit);
            _SaveRobotCommand = new DelegateCommand(OnSaveRobotCommand, CanSaveRobot);
            _ValuesUpdatedCommand = new DelegateCommand(OnValuesUpdate, CanUpdateValues);
            SQLConnection = new SQLMediator();


        }







        private bool CanExit(object commandParameter)
        {
            return true;
        }

        private void OnExitCommand(object commandParameter)
        {
            CloseAction();
        }

        private bool CanSaveRobot(object commandParameter)
        {
            //return _IsDirty;
            return true;
        }

        private void OnSaveRobotCommand(object commandParameter)
        {
            _BackupModel = _SelectedModel;
            _IsDirty = false;
            if (SQLConnection.Connect())
            {
                SQLConnection.ModifyOrAddRobot(_SelectedModel, "dbo.UpdateRobots");
                SQLConnection.Close();
            }
            else
            {
                Console.WriteLine("Cannot connect to modify robot!");
            }
            CloseAction();
        }

        private void OnValuesUpdate(object commandParameter)
        {
            _IsDirty = true;
        }

        private bool CanUpdateValues(object commandParameter)
        {
            return true;
        }

    }
}
