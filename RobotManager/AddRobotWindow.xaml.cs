using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Logika interakcji dla klasy AddRobotWindow.xaml
    /// </summary>
    public partial class AddRobotWindow : MetroWindow
    {
        public AddRobotWindow(ObservableCollection<RobotModel> robots)
        {
            var NRviewModel = new NewRobotViewModel(robots);
            NRviewModel.CloseAction = new Action(this.Close);

            //NRviewModel.NewRobot = new RobotModel(robotModel, false);

            DataContext = NRviewModel;
            InitializeComponent();
        }

        private void SplitButton_Selected(object sender, RoutedEventArgs e)
        {

        }



    }

}
