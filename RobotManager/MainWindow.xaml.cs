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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace RobotManager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            var viewModel = new ViewModel();
            viewModel.name = "K3v1n";

            viewModel.robots = new Robot[10];
            viewModel.robots[0] = new Robot("F10N4", "Transport", "red");
            viewModel.robots[1] = new Robot("P3dr0", "Cleaning", "blue");
            viewModel.robots[2] = new Robot("1544C", "Warehouse", "pink");
            DataContext = viewModel;
            InitializeComponent();



        }


    }






}
