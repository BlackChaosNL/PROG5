using PROG5.Repository.Interfaces;
using System.Linq;

namespace PROG5.ViewModel
{
    public class NinjaViewModel
    {
        public int Id { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }

        public int RemainingGold { get; set; }

        public int Agility { get; set; }

        public int Intelligence { get; set; }

        public int Strength { get; set; }

        private INinjaEquipmentRepository ninjaEquipmentRepository;

        public NinjaViewModel(INinjaEquipmentRepository repository)
        {
            ninjaEquipmentRepository = repository;

            #region Set default stats
            Agility = 0;
            Intelligence = 0;
            Strength = 0;
            RemainingGold = Gold;
            #endregion

            #region Set the ninja's stats
            var equipment = ninjaEquipmentRepository.GetAll().Where(
                x => x.Ninja.Id == Id
            );

            foreach (var item in equipment) {
                Agility += item.Equipment.Agi;
                Intelligence += item.Equipment.Int;
                Strength += item.Equipment.Str;
                RemainingGold -= item.Equipment.Gold;
            }
            #endregion
        }
    }
}