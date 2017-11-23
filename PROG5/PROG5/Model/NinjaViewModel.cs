namespace PROG5.ViewModel
{
    public class NinjaViewModel
    {
        public int Id { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }

        public int RemainingGold
        {
            get
            {
                return Gold;
            }
        }

        public int Agility
        {
            get
            {
                return 7;
            }
        }

        public int Intelligence
        {
            get
            {
                return 5;
            }
        }

        public int Strength
        {
            get
            {
                return 3;
            }
        }

        public NinjaViewModel()
        {
            // Default values, should be overridden on instantiation
            Gold = 9001;
            Name = "John Doe";
        }
    }
}