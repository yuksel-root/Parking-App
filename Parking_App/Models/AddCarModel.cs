using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Models
{
    public class AddCarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Plate { get; set; }
        public IFormFile Image { get; set; }
        public string EntryDate { get; set; }
        public string ExpireDate { get; set; }

        public int CarCount { get; set; }

    }
}
