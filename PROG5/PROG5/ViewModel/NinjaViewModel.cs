using System.Collections.Generic;

namespace PROG5.ViewModel
{
    public class NinjaViewModel
    {
        public int Id { get; set; }
        public int Gold { get; set; }
        public ICollection<NinjaEquipmentViewModel> NinjaEquipmentViewModel { get; set; }
    }
}