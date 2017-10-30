using System.Windows;

namespace PROG5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void CloseWindow()
        {
            App.Current.MainWindow.Close();
        }
    }
}
