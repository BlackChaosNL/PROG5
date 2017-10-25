using System.Collections.ObjectModel;

namespace PROG5.Repository.Interfaces
{
    public interface IBaseInterface<T>
    {
        ObservableCollection<T> GetAll();
        bool Add(T item);
        bool Delete(T item);
        bool Update(T item);
    }
}