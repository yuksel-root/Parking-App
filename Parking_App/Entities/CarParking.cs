using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Entities
{
    public class CarParking
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ParkingId { get; set; }
        public Parking Parking { get; set; }
    }
}
