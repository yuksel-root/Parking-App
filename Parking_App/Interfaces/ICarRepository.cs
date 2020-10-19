using Parking_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Interfaces
{
   public  interface ICarRepository : IGenericRepository<Car>   
    {
        List<Parking> GetParkings(int carId);
    }
} 
