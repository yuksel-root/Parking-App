using Parking_App.Contexts;
using Parking_App.Entities;
using Parking_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public List<Parking> GetParkings(int carId)
        {
            using var context = new CarParkingContext();
            return context.Cars.Join(context.CarParkings, car => car.Id, carParking => carParking.CarId,
                 (c, cp) => new
                 {
                     car = c,
                     carParking = cp
                 }).Join(context.Parkings, t2 => t2.carParking.ParkingId, parking => parking.Id,
                 (t3, k) => new
                 {
                     car = t3.car,
                     parking = k,
                     carParking = t3.carParking
                 }).Where(I => I.car.Id == carId).Select(I => new Parking
                 {
                     Section = I.parking.Section,
                     Id = I.parking.Id
                 }).ToList();
        }
    }
}
