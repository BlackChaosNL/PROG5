using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.Repository.Interfaces;
using PROG5.View;

namespace PROG5.ViewModel
{
    public class TypeManagementViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ObservableCollection<EquipmentTypeViewModel> TypesCollection { get; set; }
        public EquipmentTypeViewModel SelectedType { get; set; }
        public string NewType { get; set; }
        public IEquipmentTypeRepository TypeRepository { get; set; }
        public TypeManagementViewModel(IEquipmentTypeRepository typeRepository)
        {
            TypeRepository = typeRepository;
            CloseCommand = new RelayCommand(Close);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            TypesCollection = TypeRepository.GetAll();
        }

        public void Delete()
        {
            if (SelectedType == null) return;
            TypeRepository.Delete(SelectedType);
            TypesCollection.Remove(TypesCollection.First(o => o.Id == SelectedType.Id));
        }

        public void Add()
        {
            if (string.IsNullOrEmpty(NewType)) return;
            var etvm = new EquipmentTypeViewModel() {Name = NewType};
            TypeRepository.Add(etvm);
            TypesCollection.Add(TypeRepository.GetAll().First(o => o.Name == etvm.Name));
        }

        public void Close()
        {
            var shop = new Shop();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = shop;
            shop.Show();
        }
    }
}