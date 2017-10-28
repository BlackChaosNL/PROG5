using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.Repository.Interfaces;

namespace PROG5.ViewModel
{
    public class ShowNinjaViewModel : ViewModelBase
    {
        public ICommand Close { get; set; }
        public ICommand CreateNinja { get; set; }
        public ICommand DeleteNinja { get; set; }
        public ICommand ShopForNinja { get; set; }
        public int SelectedNinjaAgility { get; set; }
        public int SelectedNinjaIntelligence { get; set; }
        public int SelectedNinjaStrength { get; set; }
        public int SelectedNinjaRemainingGold { get; set; }
        public ObservableCollection<NinjaViewModel> NinjaCollection { get; set; }
        private readonly INinjaRepository _ninjaRepository;

        public NinjaViewModel SelectedNinja { get; set; }

        public ShowNinjaViewModel(INinjaRepository ninjas)
        {
            _ninjaRepository = ninjas;
            NinjaCollection = ninjas.GetAll();
            Close = new RelayCommand(App.CloseWindow);
            CreateNinja = new RelayCommand(AddNinja);
            DeleteNinja = new RelayCommand(RemoveNinja);
            ShopForNinja = new RelayCommand(ShopNinja);
            SelectedNinjaAgility = 0;
            SelectedNinjaIntelligence = 0;
            SelectedNinjaStrength = 0;
            SelectedNinjaRemainingGold = 0;
        }

        public void AddNinja()
        {
            var ninja = new NinjaViewModel() {Gold = 5000, Name = "Jeroen"};
            if (!_ninjaRepository.Add(ninja)) return;
            NinjaCollection.Add(ninja);
        }

        public void RemoveNinja()
        {
            //WIP
            var ninja = _ninjaRepository.GetAll().First(o => o.Id == SelectedNinja.Id);
            if (_ninjaRepository.Delete(ninja))
            {
                NinjaCollection.Remove(ninja);
            }
        }

        public void ShopNinja()
        {
            
        }
    }
}