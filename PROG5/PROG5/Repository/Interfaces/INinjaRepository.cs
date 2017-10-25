using PROG5.DatabaseModel;

namespace PROG5.Repository.Interfaces
{
    public interface INinjaRepository
    {
        Ninja get(int id);
        Ninja[] getAll();
        void add();
        void update(int id, Ninja ninja); 
        void delete();
        void deleteAll();

    }
}