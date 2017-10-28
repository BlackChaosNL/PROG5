﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using PROG5.Entities;
using PROG5.Repository.Interfaces;
using PROG5.ViewModel;

namespace PROG5.Repository.Repos
{
    public class NinjaRepository : INinjaRepository
    {
        public ObservableCollection<NinjaViewModel> GetAll()
        {
            var ninjas = new ObservableCollection<NinjaViewModel>();
            using (var ctx = new DatabaseModelContainer())
            {
                foreach (var ninja in ctx.NinjaSet)
                {
                    ninjas.Add(new NinjaViewModel(){
                        Id = ninja.Id,
                        Gold = ninja.Gold,
                        Name = ninja.Name
                    });
                }

            }
            return ninjas;
        }

        public bool Add(NinjaViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                var i = GetAll().First(o => o.Name == item.Name);
                if (i != null) return false;
                ctx.NinjaSet.Add(new Ninja(){
                    Gold = item.Gold,
                    Name = item.Name
                });
                ctx.SaveChanges();
                return true;
            }
        }

        public bool Delete(NinjaViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                var i = GetAll().First(o => o.Id == item.Id);
                if (i == null) return false;
                ctx.NinjaSet.Remove(new Ninja() { Id = item.Id });
                ctx.SaveChanges();
                return true;
            }
        }

        public bool Update(NinjaViewModel item)
        {
            using (var ctx = new DatabaseModelContainer())
            {
                var i = GetAll().First(o => o.Id == item.Id);
                if (i == null) return false;
                var ninja = ctx.NinjaSet.Find(new Ninja() {Id = item.Id});
                ninja.Gold = item.Gold;
                ninja.Name = item.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}