using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager
{
    class ModifySelectedRobotViewModel : ViewModelBase
    {

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
            set => SetProperty(ref _SelectedModel, value);
        }

        


    }
}
