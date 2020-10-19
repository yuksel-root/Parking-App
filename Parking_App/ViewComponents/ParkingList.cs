using Microsoft.AspNetCore.Mvc;
using Parking_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.ViewComponents
{
    public class ParkingList : ViewComponent
    {
        private readonly IParkingRepository _parkingRepository;
        public ParkingList(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_parkingRepository.GetAllData());
        }
    }
}
