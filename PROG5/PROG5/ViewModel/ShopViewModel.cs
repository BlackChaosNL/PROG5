using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.Repository.Interfaces;
using PROG5.View;

namespace PROG5.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; set; }
        public ICommand ItemCommand { get; set; }
        public ICommand TypeCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        public NinjaViewModel Ninja { get; set; }
        public EquipmentViewModel SelectedEquipment { get; set; }
        public EquipmentTypeViewModel SavedEquipmentTypeViewModel { get; set; }
        public EquipmentTypeViewModel SelectedEquipmentType
        {
            get => SavedEquipmentTypeViewModel;
            set
            {
                // Update the equipment list
                Equipment = EquipmentRepository.GetAllFromType(value);
                // Save the newly selected type
                SavedEquipmentTypeViewModel = value;
            }
        }
        public ObservableCollection<EquipmentTypeViewModel> EquipmentType => TypeRepository.GetAll();
        public ObservableCollection<EquipmentViewModel> Equipment { get; set; }
        public IEquipmentTypeRepository TypeRepository { get; set; }
        public IEquipmentRepository EquipmentRepository { get; set; }
        public INinjaEquipmentRepository NinjaEquipmentRepository { get; set; }
        public ShopViewModel(ShowNinjaViewModel sh,
            IEquipmentTypeRepository types,
            IEquipmentRepository equipment,
            INinjaEquipmentRepository link)
        {
            Ninja = sh.SelectedNinja;
            TypeRepository = types;
            NinjaEquipmentRepository = link;
            EquipmentRepository = equipment;
            CloseCommand = new RelayCommand(Close);
            ItemCommand = new RelayCommand(ItemManagementWindow);
            TypeCommand = new RelayCommand(TypeManagementWindow);
            BuyCommand = new RelayCommand(BuyItem);
        }

        public void BuyItem()
        {

        }

        #region Controls
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

        public void Close()
        {
            var main = new MainWindow();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = main;
            main.Show();
        }
        #endregion
    }
}