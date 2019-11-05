using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ModifySelectedRobotWindow(ObservableCollection<RobotModel> robots, int robotIndex)
        {
            var MSRviewModel = new ModifySelectedRobotViewModel
            {
                //BackupModel = selectedRobot,
                Robots = robots,
                SelectedModel = new RobotModel(robots[robotIndex], true),
                RobotIndex = robotIndex,
                IsDirty = false,
                CloseAction = new Action(this.Close)
             };

            DataContext = MSRviewModel;
            InitializeComponent();
        }
    }
}
