using Parking_App.Contexts;
using Parking_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Repositories
{
    public class GenericRepository<Table> where Table:class,new() 
    {
        public void Add(Table table)
        {
            using var context = new CarParkingContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }
               
        public void Update(Table table)
        {
            using var context = new CarParkingContext();
            context.Set<Table>().Update(table);
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

        public Table GetWithIdParkings(int id)
        {
            using var context = new CarParkingContext();
            return context.Set<Table>().Find(id);
        }
    }
}
