/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PROG5"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PROG5.Repository.Interfaces;
using PROG5.Repository.Repos;
using PROG5.Entities;

namespace PROG5.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            // Register the Entities in our program, we love us some domain specific classes.
            SimpleIoc.Default.Register<DatabaseModelContainer>();
            // Set some repositories for data access.
            SimpleIoc.Default.Register<INinjaRepository, NinjaRepository>();
            SimpleIoc.Default.Register<IEquipmentRepository, EquipmentRepository>();
            SimpleIoc.Default.Register<IEquipmentTypeRepository, EquipmentTypeRepository>();
            SimpleIoc.Default.Register<INinjaEquipmentRepository, NinjaEquipmentRepository>();
            // Add the VMs, we love some virtual machines.
            SimpleIoc.Default.Register<NinjaViewModel>();
            SimpleIoc.Default.Register<ShowNinjaViewModel>();
            SimpleIoc.Default.Register<ShopViewModel>();
            SimpleIoc.Default.Register<NinjaEquipmentViewModel>();
            SimpleIoc.Default.Register<EquipmentTypeViewModel>();
            SimpleIoc.Default.Register<EquipmentViewModel>();
            SimpleIoc.Default.Register<AddNinjaDialogViewModel>();
            SimpleIoc.Default.Register<TypeManagementViewModel>();
        }

        public ShowNinjaViewModel Main => ServiceLocator.Current.GetInstance<ShowNinjaViewModel>();
        public ShopViewModel Shop => ServiceLocator.Current.GetInstance<ShopViewModel>();
        public AddNinjaDialogViewModel Popup => ServiceLocator.Current.GetInstance<AddNinjaDialogViewModel>();
        public TypeManagementViewModel Type => ServiceLocator.Current.GetInstance<TypeManagementViewModel>();

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<INinjaRepository>();
        }
    }
}