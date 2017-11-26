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
                    ninjaEquipment.Add(new NinjaEquipmentViewModel {
                        Id = equipment.Id,
                        Equipment = new EquipmentViewModel {
                            Id = equipment.Equipment.Id,
                            Agi = equipment.Equipment.Agi,
                            Gold = equipment.Equipment.Gold,
                            Int = equipment.Equipment.Int,
                            Name = equipment.Equipment.Name
                        },
                        Ninja = new NinjaViewModel {
                            Id = equipment.Ninja.Id,
                            Gold = equipment.Ninja.Gold,
                            Name = equipment.Ninja.Name
                        }
                    });
                }
            }

            return ninjaEquipment;
        }

        public bool Add(NinjaEquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                ctx.NinjaEquipmentSet.Add(new NinjaEquipment {
                    Ninja = ctx.NinjaSet.FirstOrDefault(o => o.Id == item.Ninja.Id),
                    Equipment = ctx.EquipmentSet.FirstOrDefault(o => o.Id == item.Equipment.Id)
                });
                ctx.SaveChanges();

                return true;
            }
        }

        public bool Delete(NinjaEquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                ctx.NinjaEquipmentSet.Remove(ctx.NinjaEquipmentSet.First(o => o.Ninja.Id == item.Ninja.Id && o.Equipment.Id == item.Equipment.Id));
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