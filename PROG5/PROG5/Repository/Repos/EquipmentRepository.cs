﻿using System.Collections.ObjectModel;
using System.Linq;
using PROG5.Entities;
using PROG5.Repository.Interfaces;
using PROG5.ViewModel;

namespace PROG5.Repository.Repos
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public ObservableCollection<EquipmentViewModel> GetAll()
        {
            var equipment = new ObservableCollection<EquipmentViewModel>();
            using (var ctx = new DatabaseModelContainer()) {
                foreach (var item in ctx.EquipmentSet.ToList()) {
                    equipment.Add(new EquipmentViewModel() {
                        Id = item.Id,
                        Agi = item.Agi,
                        Str = item.Str,
                        Int = item.Int,
                        Gold = item.Gold,
                        Name = item.Name,
                        EquipmentTypeViewModel = new EquipmentTypeViewModel()
                        {
                            Id = item.EquipmentType.Id,
                            Name = item.EquipmentType.Name
                        }
                    });
                }
            }
            return equipment;
        }

        public ObservableCollection<EquipmentViewModel> GetAllFromType(EquipmentTypeViewModel type)
        {
            var equipment = new ObservableCollection<EquipmentViewModel>();

            using (var ctx = new DatabaseModelContainer()) {
                var results = ctx.EquipmentSet.ToList();

                foreach (var item in results) {
                    if (item.EquipmentType.Id != type.Id) {
                        continue;
                    }

                    equipment.Add(new EquipmentViewModel() {
                        Id = item.Id,
                        Agi = item.Agi,
                        Str = item.Str,
                        Int = item.Int,
                        Gold = item.Gold,
                        Name = item.Name,
                        EquipmentTypeViewModel = new EquipmentTypeViewModel {
                            Id = item.EquipmentType.Id,
                            Name = item.EquipmentType.Name,
                        },
                    });
                }
            }

            return equipment;
        }

        public bool Add(EquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer()) {
                ctx.EquipmentSet.Add(new Equipment() {
                    Agi = item.Agi,
                    Str = item.Str,
                    Int = item.Int,
                    Name = item.Name,
                    Gold = item.Gold,
                    EquipmentType = ctx.EquipmentTypeSet.First(o => o.Id == item.EquipmentTypeViewModel.Id)
                });
                ctx.SaveChanges();
            }
            return true;
        }

        public bool Delete(EquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer()) {
                ctx.EquipmentSet.Remove(ctx.EquipmentSet.First(o => o.Id == item.Id) ?? new Equipment());
                ctx.SaveChanges();
            }
            return true;
        }

        public bool Update(EquipmentViewModel item)
        {
            using (var ctx = new DatabaseModelContainer()) {
                var equipment = ctx.EquipmentSet.First(o => o.Id == item.Id);
                equipment.Agi = item.Agi;
                equipment.Int = item.Int;
                equipment.Str = item.Str;
                equipment.Gold = item.Gold;
                equipment.Name = item.Name;
                equipment.EquipmentType = ctx.EquipmentTypeSet.First(o => o.Id == item.EquipmentTypeViewModel.Id);
                ctx.SaveChanges();
            }
            return true;
        }
    }
}