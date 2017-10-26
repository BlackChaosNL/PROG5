﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5.Repository.Interfaces;

namespace PROG5.ViewModel
{
    public class ShowNinjaViewModel : ViewModelBase
    {
        public ICommand Close { get; set; }
        public ICommand CreateNinja { get; set; }
        public ICommand DeleteNinja { get; set; }
        public int SelectedNinjaAgility { get; set; }
        public int SelectedNinjaIntelligence { get; set; }
        public int SelectedNinjaStrength { get; set; }
        public int SelectedNinjaRemainingGold { get; set; }
        public ObservableCollection<NinjaViewModel> NinjaCollection { get; set; }

        public string SelectedNinja { get; set; }

        public ShowNinjaViewModel(INinjaRepository ninjas)
        {
            NinjaCollection = ninjas.GetAll();
            Close = new RelayCommand(App.CloseWindow);
            CreateNinja = new RelayCommand(AddNinja);
            DeleteNinja = new RelayCommand(RemoveNinja);
            SelectedNinjaAgility = 0;
            SelectedNinjaIntelligence = 0;
            SelectedNinjaStrength = 0;
            SelectedNinjaRemainingGold = 0;
        }

        public void AddNinja()
        {
            
        }

        public void RemoveNinja()
        {
            
        }
    }
}