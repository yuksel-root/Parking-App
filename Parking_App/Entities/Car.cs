using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Entities
{
    [Dapper.Contrib.Extensions.Table("Cars")]
    public class Car
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [MaxLength(50)]
        public string Start_date { get; set; }
        [MaxLength(50)]
        public string End_date { get; set; }
        [MaxLength(20)]
        public string Plate { get; set; }

        public int CarCount { get; set; }
        public List<CarParking> CarParkings { get; set; }

      
    }
}
