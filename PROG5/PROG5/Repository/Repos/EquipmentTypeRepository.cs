using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using PROG5.Entities;
using PROG5.Repository.Interfaces;
using PROG5.ViewModel;

namespace PROG5.Repository.Repos
{
    public class EquipmentTypeRepository : IBaseInterface<EquipmentTypeViewModel>
    {
        public ObservableCollection<EquipmentTypeViewModel> GetAll()
        {
            var types = new ObservableCollection<EquipmentTypeViewModel>();
            using (var ctx = new DatabaseModelContainer())
            {
                foreach (var item in ctx.EquipmentTypeSet)
                {
                    types.Add(new EquipmentTypeViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }
            return types;
        }

        public bool Add(EquipmentTypeViewModel item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(EquipmentTypeViewModel item)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(EquipmentTypeViewModel item)
        {
            throw new System.NotImplementedException();
        }
    }
}