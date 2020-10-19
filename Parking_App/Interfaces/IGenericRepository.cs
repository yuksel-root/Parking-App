using Parking_App.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Interfaces
{
   public interface IGenericRepository<Table> where Table: class,new()
    {
        public void Update(Table table)
        {
            using var context = new CarParkingContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }
        public void Add(Table table)
        {
            using var context = new CarParkingContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Remove(Table table)
        {
            using var context = new CarParkingContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }

        public List<Table> GetAllData()
        {
            using var context = new CarParkingContext();
            return context.Set<Table>().ToList();
        }

        public Table GetWithId(int id)
        {
            using var context = new CarParkingContext();
            return context.Set<Table>().Find(id);
        }


    }
}
