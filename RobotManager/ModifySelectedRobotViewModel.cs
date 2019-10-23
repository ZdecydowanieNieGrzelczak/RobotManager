using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotManager
{
    class ModifySelectedRobotViewModel : ViewModelBase
    {
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



        }







        private bool CanExit(object commandParameter)
        {
            return true;
        }

        private void OnExitCommand(object commandParameter)
        {

        }

        private bool CanSaveRobot(object commandParameter)
        {
            return _IsDirty;
        }

        private void OnSaveRobotCommand(object commandParameter)
        {
            _BackupModel = _SelectedModel;
            _IsDirty = false;
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
