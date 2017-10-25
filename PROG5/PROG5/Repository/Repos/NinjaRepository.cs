using System.Net.NetworkInformation;
using PROG5.DatabaseModel;
using PROG5.Repository.Interfaces;

namespace PROG5.Repository.Repos
{
    public class NinjaRepository : INinjaRepository
    {
        public Ninja get(int id)
        {
            using (var context = new Ninja())
            {
                
            }
        }

        public Ninja[] getAll()
        {
            throw new System.NotImplementedException();
        }

        public void add()
        {
            throw new System.NotImplementedException();
        }

        public void update(int id, Ninja ninja)
        {
            throw new System.NotImplementedException();
        }

        public void delete()
        {
            throw new System.NotImplementedException();
        }

        public void deleteAll()
        {
            throw new System.NotImplementedException();
        }
    }
}