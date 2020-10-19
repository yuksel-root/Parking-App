using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Entities
{
    public class Parking
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Section { get; set; }

        public List<CarParking> CarParkings { get; set; }
    }
}
