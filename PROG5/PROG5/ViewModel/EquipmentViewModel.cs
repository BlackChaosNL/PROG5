namespace PROG5.ViewModel
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        public int Int { get; set; }
        public int Str { get; set; }
        public int Gold { get; set; }
        public string Name { get; set; }
        public EquipmentTypeViewModel EquipmentTypeViewModel { get; set; }
    }
}