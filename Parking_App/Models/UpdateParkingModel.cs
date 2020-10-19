using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.Models
{
    public class UpdateParkingModel
    {
        public int Id{get; set;}
        public string Section { get; set; }
    }
}
