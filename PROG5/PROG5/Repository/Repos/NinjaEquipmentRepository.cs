using System.CodeDom;
using System.Collections.ObjectModel;
using System.Linq;
using PROG5.Entities;
using PROG5.Repository.Interfaces;
using PROG5.ViewModel;

namespace PROG5.Repository.Repos
{
    public class NinjaEquipmentRepository : INinjaEquipmentRepository
    {
        public ObservableCollection<NinjaEquipmentViewModel> GetAll()
        {
            var ninjaEquipment = new ObservableCollection<NinjaEquipmentViewModel>();
            using (var ctx = new DatabaseModelContainer())
            {
                foreach (var equipment in ctx.NinjaEquipmentSet.ToList())
                {
                    ninjaEquipment.Add(new NinjaEquipmentViewModel { Id = equipment.Id,
                        Equipment = new EquipmentViewModel { Id = equipment.Equipment.Id },
                        Ninja = new NinjaViewModel { Id = equipment.Ninja.Id }}
                    );
                }
            }
            return ninjaEquipment;
        }

        public bool Add(NinjaEquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                var n = ctx.NinjaSet.First(o => o.Id == item.Ninja.Id);
                var e = ctx.EquipmentSet.First(o => o.Id == item.Equipment.Id);
                ctx.NinjaEquipmentSet.Add(new NinjaEquipment(){ Ninja = n, Equipment = e });
                ctx.SaveChanges();
                return true;
            }
        }

        public bool Delete(NinjaEquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                ctx.NinjaEquipmentSet.Remove(new NinjaEquipment() { Id = item.Id });
                ctx.SaveChanges();
                return true;
            }
        }

        // Not required to update.
        public bool Update(NinjaEquipmentViewModel item)
        {
            throw new System.NotImplementedException();
        }
    }
}