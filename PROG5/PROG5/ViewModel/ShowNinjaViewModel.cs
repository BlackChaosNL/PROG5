using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using PROG5.Repository.Interfaces;

namespace PROG5.ViewModel
{
    public class ShowNinjaViewModel : ViewModelBase
    {
        public ObservableCollection<NinjaViewModel> NinjaCollection { get; set; }

        public ShowNinjaViewModel(INinjaRepository ninjas)
        {
            NinjaCollection = ninjas.GetAll();
        }

        
    }
}