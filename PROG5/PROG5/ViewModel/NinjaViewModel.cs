namespace PROG5.ViewModel
{
    public class NinjaViewModel
    {
        public int Id { get; set; }
        public int Gold { get; set; }
        public string Name { get; set; }

        public NinjaViewModel()
        {
            Gold = 9001;
            Name = "John Doe";
        }
    }
}