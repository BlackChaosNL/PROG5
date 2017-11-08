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

        public ICommand SellCommand { get; set; }

        public NinjaViewModel Ninja { get; set; }

        public EquipmentViewModel SelectedEquipment {
            get => _selectedEquipment;

            set
            {
                _selectedEquipment = value;

                // TODO: Check if the currently selected ninja already has the currently selected equipment
                hasEquipment = false;
            }
        }

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

        private bool hasEquipment;

        private EquipmentViewModel _selectedEquipment;

        public ShopViewModel(
            ShowNinjaViewModel sh,
            IEquipmentTypeRepository types,
            IEquipmentRepository equipment,
            INinjaEquipmentRepository link
        ) {
            hasEquipment = false;
            Ninja = sh.SelectedNinja; // TODO: Currently only set on the FIRST time the shop opens, never updated, it should update every time the shop opens
            TypeRepository = types;
            NinjaEquipmentRepository = link;
            EquipmentRepository = equipment;
            CloseCommand = new RelayCommand(Close);
            ItemCommand = new RelayCommand(ItemManagementWindow);
            TypeCommand = new RelayCommand(TypeManagementWindow);
            BuyCommand = new RelayCommand(BuyItem, () => SelectedEquipment != null && SelectedEquipment.Gold <= Ninja.Gold && !hasEquipment);
            SellCommand = new RelayCommand(SellItem, () => SelectedEquipment != null && hasEquipment);
        }

        public void BuyItem()
        {

        }

        public void SellItem()
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