using System.Collections.ObjectModel;
using PROG5.ViewModel;

namespace PROG5.Repository.Interfaces
{
    public interface IEquipmentRepository : IBaseInterface<EquipmentViewModel>
    {
        ObservableCollection<EquipmentViewModel> GetAllFromType(EquipmentTypeViewModel type);
    }
}