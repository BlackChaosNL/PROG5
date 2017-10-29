using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.Repository.Interfaces;

namespace PROG5.ViewModel
{

    public class AddNinjaDialogViewModel : ViewModelBase
    {
        public ICommand AddNinjaCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public INinjaRepository NinjaRepository { get; set; }
        public ShowNinjaViewModel Ninja { get; set; }

        public AddNinjaDialogViewModel(INinjaRepository ninjaRepository, 
            ShowNinjaViewModel ninja) 
        {
            NinjaRepository = ninjaRepository;
            Ninja = ninja;
            AddNinjaCommand = new RelayCommand(AddNinja);
            CloseCommand = new RelayCommand(Close);
        }

        public void AddNinja()
        {
            var ninja = new NinjaViewModel(){
                Gold = Gold,
                Name = Name
            };
            if (!NinjaRepository.Add(ninja)) return;
            Ninja.UpdateCollection();
            Close();
        }

        public void Close()
        {
            var main = new MainWindow();
            (App.Current.MainWindow).Close();
            App.Current.MainWindow = main;
            main.Show();
        }
    }
}