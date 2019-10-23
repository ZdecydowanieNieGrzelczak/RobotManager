using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RobotManager
{
    /// <summary>
    /// Interaction logic for ModifySelectedRobotWindow.xaml
    /// </summary>
    public partial class ModifySelectedRobotWindow : MetroWindow
    {
        public ModifySelectedRobotWindow(RobotModel selectedRobot)
        {
            var MSRviewModel = new ModifySelectedRobotViewModel
            {
                BackupModel = selectedRobot,
                SelectedModel = new RobotModel(selectedRobot),
                IsDirty = false
        };

            DataContext = MSRviewModel;
            InitializeComponent();
        }
    }
}
