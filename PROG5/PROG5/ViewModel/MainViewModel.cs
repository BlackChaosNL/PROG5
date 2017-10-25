using GalaSoft.MvvmLight;
using PROG5.Repository.Interfaces;

namespace PROG5.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INinjaRepository repository { get; set; }
        public MainViewModel(INinjaRepository repository)
        {
            this.repository = repository;
        }
    }
}