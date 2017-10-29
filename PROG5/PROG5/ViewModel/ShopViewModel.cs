using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.View;

namespace PROG5.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; set; }
        public ICommand ItemCommand { get; set; }
        public ICommand TypeCommand { get; set; }
        public NinjaViewModel Ninja { get; set; }
        public EquipmentViewModel SelectedEquipment { get; set; }
        public ObservableCollection<EquipmentTypeViewModel> EquipmentType { get; set; }
        public ShopViewModel(ShowNinjaViewModel sh)
        {
            Ninja = sh.SelectedNinja;
            CloseCommand = new RelayCommand(ClosePls);
            ItemCommand = new RelayCommand(ItemManagementWindow);
            TypeCommand = new RelayCommand(TypeManagementWindow);
        }

        public void TypeManagementWindow()
        {
            var window = new TypeManagementWindow();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = window;
            window.Show();
        }

        public void ItemManagementWindow()
        {
            var window = new ItemManagementWindow();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = window;
            window.Show();
        }

        public void ClosePls()
        {
            var main = new MainWindow();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = main;
            main.Show();
        }
    }
}