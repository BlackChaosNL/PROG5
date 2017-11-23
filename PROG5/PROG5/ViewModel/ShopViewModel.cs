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
        #region Data
        public ICommand CloseCommand { get; set; }

        public ICommand ItemCommand { get; set; }

        public ICommand TypeCommand { get; set; }

        public ICommand BuyCommand { get; set; }

        public ICommand SellCommand { get; set; }

        public IEquipmentTypeRepository TypeRepository { get; set; }

        public IEquipmentRepository EquipmentRepository { get; set; }

        public INinjaEquipmentRepository NinjaEquipmentRepository { get; set; }

        public INinjaRepository NinjaRepository { get; set; }

        private bool _hasEquipment;

        private EquipmentViewModel _selectedEquipment;

        private ObservableCollection<EquipmentViewModel> _equipment;

        private ShowNinjaViewModel _showNinjaViewModel;

        public NinjaViewModel Ninja => _showNinjaViewModel.SelectedNinja;

        public EquipmentViewModel SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment = value;

                var repo = NinjaEquipmentRepository.GetAll();
                var result = repo.FirstOrDefault(
                    o => o.Ninja.Id == Ninja.Id && o.Equipment.Id == _selectedEquipment.Id
                );
                
                _hasEquipment = (result != null);

                RaisePropertyChanged();
            }
        }

        public EquipmentTypeViewModel SavedEquipmentTypeViewModel { get; set; }

        public EquipmentTypeViewModel SelectedEquipmentType
        {
            get => SavedEquipmentTypeViewModel;
            set
            {
                SavedEquipmentTypeViewModel = value;
                GetEquipment = EquipmentRepository.GetAllFromType(value);
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<EquipmentTypeViewModel> EquipmentType => TypeRepository.GetAll();

        public ObservableCollection<EquipmentViewModel> GetEquipment
        {
            get => _equipment;
            set
            {
                _equipment = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ShopViewModel(
            ShowNinjaViewModel sh,
            IEquipmentTypeRepository types,
            IEquipmentRepository equipment,
            INinjaEquipmentRepository link,
            INinjaRepository ninja
        ) {
            _showNinjaViewModel = sh;
            _hasEquipment = false;
            TypeRepository = types; 
            NinjaEquipmentRepository = link;
            EquipmentRepository = equipment;
            NinjaRepository = ninja;
            CloseCommand = new RelayCommand(Close);
            ItemCommand = new RelayCommand(ItemManagementWindow);
            TypeCommand = new RelayCommand(TypeManagementWindow);
            BuyCommand = new RelayCommand(BuyItem, () => SelectedEquipment != null && SelectedEquipment.Gold <= Ninja.Gold && !_hasEquipment);
            SellCommand = new RelayCommand(SellItem, () => SelectedEquipment != null && _hasEquipment);
        }

        public void BuyItem()
        {
            NinjaEquipmentRepository.Add(new NinjaEquipmentViewModel()
            {
                Equipment = SelectedEquipment,
                Ninja = Ninja
            });
            Ninja.Gold -= SelectedEquipment.Gold;
            NinjaRepository.Update(Ninja);
            RaisePropertyChanged();
        }

        public void SellItem()
        {

            Ninja.Gold += SelectedEquipment.Gold;
            NinjaRepository.Update(Ninja);
            RaisePropertyChanged();
        }

        #region Main buttons
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