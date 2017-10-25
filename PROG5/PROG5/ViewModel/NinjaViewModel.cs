using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using PROG5.Repository.Interfaces;

namespace PROG5.ViewModel
{
    public class NinjaViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public int Gold { get; set; }
        public ObservableCollection<NinjaEquipmentViewModel> NinjaEquipmentViewModel { get; set; }
    }
}