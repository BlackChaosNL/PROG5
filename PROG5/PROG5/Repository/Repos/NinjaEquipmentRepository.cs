using System.CodeDom;
using System.Collections.ObjectModel;
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
                foreach (var equipment in ctx.NinjaEquipmentSet)
                {
                    ninjaEquipment.Add(new NinjaEquipmentViewModel() { Id = equipment.Id,
                        EquipmentViewModel = new EquipmentViewModel() { Id = equipment.Equipment.Id },
                        NinjaViewModel = new NinjaViewModel() { Id = equipment.Ninja.Id }}
                    );
                }
            }
            return ninjaEquipment;
        }

        public bool Add(NinjaEquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                ctx.NinjaEquipmentSet.Add(new NinjaEquipment(){Ninja = new Ninja() {Id = item.NinjaViewModel.Id},
                    Equipment = new Equipment(){ Id = item.EquipmentViewModel.Id } });
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