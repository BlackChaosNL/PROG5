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

        private bool _hasEquipmentType;

        private EquipmentViewModel _selectedEquipment;

        private ObservableCollection<EquipmentViewModel> _equipment;

        public NinjaViewModel GetNinjaViewModel
        {
            get => Ninja;
            set
            {
                Ninja = value;
                RaisePropertyChanged();
            }
        }
        
        public NinjaViewModel Ninja { get; set; }

        public EquipmentViewModel SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment = value;

                var repo = NinjaEquipmentRepository.GetAll();
                var equipmentResult = repo.Any(o => ValidEquipment(o, _selectedEquipment?.Id ?? 0));
                var equipmentTypeResult = _selectedEquipment != null && repo.Any(o => ValidEquipmentType(o));

                _hasEquipment = equipmentResult;
                _hasEquipmentType = equipmentTypeResult;

                RaisePropertyChanged();
            }
        }

        private bool ValidEquipment(
            NinjaEquipmentViewModel o,
            int equipmentId
        )
        {
            if (o.Ninja.Id != Ninja.Id) {
                return false;
            }

            if (o.Equipment.Id != equipmentId) {
                return false;
            }

            return true;
        }

        private bool ValidEquipmentType(
            NinjaEquipmentViewModel o
        )
        {
            if (o.Ninja.Id != Ninja.Id) {
                return false;
            }

            EquipmentViewModel equipment = EquipmentRepository.GetAll().First(x => x.Id == _selectedEquipment.Id);

            if (o.Equipment.Id != equipment.EquipmentTypeViewModel.Id) {
                return false;
            }

            return true;
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
        )
        {
            GetNinjaViewModel = sh.SelectedNinja;
            _hasEquipment = false;
            _hasEquipmentType = false;
            TypeRepository = types; 
            NinjaEquipmentRepository = link;
            EquipmentRepository = equipment;
            NinjaRepository = ninja;
            CloseCommand = new RelayCommand(Close);
            ItemCommand = new RelayCommand(ItemManagementWindow);
            TypeCommand = new RelayCommand(TypeManagementWindow);
            BuyCommand = new RelayCommand(BuyItem, ReturnBuyItem);
            SellCommand = new RelayCommand(SellItem, ReturnSellItem);
        }

        private bool ReturnBuyItem()
        {
            // Equipment has to be selected
            if (SelectedEquipment == null) {
                System.Console.WriteLine("Nothing selected");

                return false;
            }

            // Ninja must have enough gold
            if (Ninja.RemainingGold < SelectedEquipment.Gold) {
                System.Console.WriteLine("Too poor");

                return false;
            }

            // Ninja may not have two of the same equipment types
            if (!_hasEquipmentType) {
                System.Console.WriteLine("Already have this type");

                return false;
            }

            return true;
        }

        private bool ReturnSellItem()
        {
            // An item has to be selected
            if (SelectedEquipment != null) {
                System.Console.WriteLine("Nothing selected");

                return false;
            }

            // Ninja must have this equipment piece to sell it
            if (!_hasEquipment) {
                System.Console.WriteLine("Not owned");
                return false;
            }

            return true;
        }

        public void BuyItem()
        {
            NinjaEquipmentRepository.Add(new NinjaEquipmentViewModel()
            {
                Equipment = SelectedEquipment,
                Ninja = Ninja
            });

            GetNinjaViewModel.RemainingGold -= SelectedEquipment.Gold;
            NinjaRepository.Update(GetNinjaViewModel);
            RaisePropertyChanged();
        }

        public void SellItem()
        {
            NinjaEquipmentRepository.Delete(new NinjaEquipmentViewModel()
            {
                Equipment = SelectedEquipment,
                Ninja = Ninja
            });

            GetNinjaViewModel.RemainingGold += SelectedEquipment.Gold;
            NinjaRepository.Update(GetNinjaViewModel);
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