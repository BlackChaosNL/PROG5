using System.Collections.ObjectModel;
using System.Linq;
using PROG5.Entities;
using PROG5.Repository.Interfaces;
using PROG5.ViewModel;

namespace PROG5.Repository.Repos
{
    public class EquipmentTypeRepository : IEquipmentTypeRepository
    {
        public ObservableCollection<EquipmentTypeViewModel> GetAll()
        {
            var types = new ObservableCollection<EquipmentTypeViewModel>();
            using (var ctx = new DatabaseModelContainer()) {
                foreach (var item in ctx.EquipmentTypeSet) {
                    types.Add(new EquipmentTypeViewModel() {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }
            return types;
        }

        public bool Add(EquipmentTypeViewModel item)
        {
            using (var ctx = new DatabaseModelContainer()) {
                var type = ctx.EquipmentTypeSet.Add(new EquipmentType() { Name = item.Name });
                ctx.SaveChanges();
                return type != null;
            }
        }

        public bool Delete(EquipmentTypeViewModel item)
        {
            using (var ctx = new DatabaseModelContainer()) {
                ctx.EquipmentTypeSet.Remove(ctx.EquipmentTypeSet.First(o => o.Id == item.Id));
                ctx.SaveChanges();
                return true;
            }
        }

        public bool Update(EquipmentTypeViewModel item)
        {
            throw new System.NotImplementedException();
        }
    }
}