using GalaSoft.MvvmLight.Command;
using PROG5.Controllers;
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

namespace PROG5
{
    /// <summary>
    /// Interaction logic for AddNinjaWindow.xaml
    /// </summary>
    public partial class AddNinjaWindow : Window
    {
        public AddNinjaController controller;
        public ICommand CloseWindow;

        public AddNinjaWindow(AddNinjaController controller)
        {
            this.controller = controller;

            CloseWindow = new RelayCommand(CloseWindowHandler);

            InitializeComponent();
        }

        private void CloseWindowHandler()
        {
            Close();
        }
    }
}
