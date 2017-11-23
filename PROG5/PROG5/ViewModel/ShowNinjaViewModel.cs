using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.Repository.Interfaces;
using PROG5.View;

namespace PROG5.ViewModel
{
    public class ShowNinjaViewModel : ViewModelBase
    {
        public ICommand Close { get; set; }

        public ICommand CreateNinja { get; set; }

        public ICommand DeleteNinja { get; set; }

        public ICommand ShopForNinja { get; set; }

        public NinjaViewModel SelectedNinja {
            get
            {
                return _selectedNinja;
            }

            set
            {
                _selectedNinja = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<NinjaViewModel> NinjaCollection { get; set; }

        private readonly INinjaRepository _ninjaRepository;

        private NinjaViewModel _selectedNinja;

        public ShowNinjaViewModel(INinjaRepository ninjas)
        {
            _ninjaRepository = ninjas;
            UpdateCollection();
            Close = new RelayCommand(App.CloseWindow);
            CreateNinja = new RelayCommand(AddNinja);
            DeleteNinja = new RelayCommand(RemoveNinja, () => SelectedNinja != null);
            ShopForNinja = new RelayCommand(ShopNinja, () => SelectedNinja != null);
        }

        public void AddNinja()
        {
            var window = new AddNinjaWindow();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = window;
            window.Show();
        }

        public void RemoveNinja()
        {
            var ninja = _ninjaRepository.GetAll().First(o => o.Name == SelectedNinja.Name);

            if (_ninjaRepository.Delete(ninja)) {
                NinjaCollection.Remove(NinjaCollection.First(o => o.Id == SelectedNinja.Id));
            }

            UpdateCollection();
        }

        public void ShopNinja()
        {
            var shop = new Shop();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = shop;
            shop.Show();
        }

        public void UpdateCollection()
        {
            NinjaCollection = _ninjaRepository.GetAll();
        }
    }
}