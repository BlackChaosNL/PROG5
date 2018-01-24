using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.Repository.Interfaces;
using PROG5.View;

namespace PROG5.ViewModel
{
    public class ItemManagementViewModel : ViewModelBase
    {
        public IEquipmentRepository EquipmentRepository { get; set; }
        public IEquipmentTypeRepository EquipmentTypeRepository { get; set; }
        public ObservableCollection<EquipmentTypeViewModel> EquipmentTypeCollection => EquipmentTypeRepository.GetAll();
        public ObservableCollection<EquipmentViewModel> EquipmentCollection { get; set; }
        public EquipmentViewModel Equipment { get; set; }
        public EquipmentViewModel NewEquipmentVm { get; set; }
        public EquipmentViewModel NewEquipmentViewModel
        {
            get => NewEquipmentViewModel;
            set
            {
                NewEquipmentVm = value;
                RaisePropertyChanged();
            }
        }
        public EquipmentViewModel SelectedEquipmentViewModel
        {
            get => Equipment;
            set
            {
                Equipment = value;
                RaisePropertyChanged();
            }
        }

        public ItemManagementViewModel(IEquipmentTypeRepository equipmentType, 
            IEquipmentRepository equipment)
        {
            EquipmentTypeRepository = equipmentType;
            EquipmentRepository = equipment;
            AddCommand = new RelayCommand(Add, () => CheckAddableEtvm(NewEquipmentViewModel));
            RemoveCommand = new RelayCommand(Remove, () => SelectedEquipmentViewModel != null);
            ExitCommand = new RelayCommand(Exit);
            NewEquipmentViewModel = new EquipmentViewModel();
        }

        #region Buttons
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public void Add()
        {
            
        }
        public void Remove()
        {
            
        }
        public void Exit()
        {
            var shop = new Shop();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = shop;
            shop.Show();
        }
        #endregion

        #region Add
        bool CheckAddableEtvm(EquipmentViewModel e)
        {
            return e.Name != null;
        }
        #endregion

        #region Remove
        private ObservableCollection<EquipmentViewModel> _equipment;
        private EquipmentViewModel _selectedEquipment;
        private EquipmentTypeViewModel _selectedEquipmentTypeViewModel;
        public EquipmentTypeViewModel GetEquipmentTypeViewModel
        {
            get => _selectedEquipmentTypeViewModel;
            set
            {
                _selectedEquipmentTypeViewModel = value;
                GetEquipment = EquipmentRepository.GetAllFromType(_selectedEquipmentTypeViewModel);
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<EquipmentViewModel> GetEquipment
        {
            get => _equipment;
            set
            {
                _equipment = value;
                RaisePropertyChanged();
            }
        }
        public EquipmentViewModel SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}
