using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PROG5.Repository.Interfaces;
using PROG5.Repository.Repos;
using PROG5.Entities;

namespace PROG5.ViewModel
{
    public class ViewModelLocator
    {
        public ShowNinjaViewModel Main => ServiceLocator.Current.GetInstance<ShowNinjaViewModel>();
        public ShopViewModel Shop => ServiceLocator.Current.GetInstance<ShopViewModel>();
        public AddNinjaDialogViewModel Popup => ServiceLocator.Current.GetInstance<AddNinjaDialogViewModel>();
        public TypeManagementViewModel Type => ServiceLocator.Current.GetInstance<TypeManagementViewModel>();
        public ItemManagementViewModel Item => ServiceLocator.Current.GetInstance<ItemManagementViewModel>();
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
            SimpleIoc.Default.Register<ItemManagementViewModel>();
        }
        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<DatabaseModelContainer>();

            // Set some repositories for data access.
            SimpleIoc.Default.Unregister<INinjaRepository>();
            SimpleIoc.Default.Unregister<IEquipmentRepository>();
            SimpleIoc.Default.Unregister<IEquipmentTypeRepository>();
            SimpleIoc.Default.Unregister<INinjaEquipmentRepository>();

            // Add the VMs, we love some virtual machines.
            SimpleIoc.Default.Unregister<NinjaViewModel>();
            SimpleIoc.Default.Unregister<ShowNinjaViewModel>();
            SimpleIoc.Default.Unregister<ShopViewModel>();
            SimpleIoc.Default.Unregister<NinjaEquipmentViewModel>();
            SimpleIoc.Default.Unregister<EquipmentTypeViewModel>();
            SimpleIoc.Default.Unregister<EquipmentViewModel>();
            SimpleIoc.Default.Unregister<AddNinjaDialogViewModel>();
            SimpleIoc.Default.Unregister<TypeManagementViewModel>();
            SimpleIoc.Default.Unregister<ItemManagementViewModel>();
        }
    }
}