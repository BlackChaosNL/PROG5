using System.Collections.ObjectModel;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using PROG5.Repository.Interfaces;

namespace PROG5.ViewModel
{
    public class ShowNinjaViewModel : ViewModelBase
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<NinjaViewModel> NinjaCollection { get; set; }

        public string SelectedNinja { get; set; }

        public ShowNinjaViewModel(INinjaRepository ninjas)
        {
            NinjaCollection = ninjas.GetAll();
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}