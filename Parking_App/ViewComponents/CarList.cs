using Microsoft.AspNetCore.Mvc;
using Parking_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Parking_App.ViewComponents
{
    public class CarList : ViewComponent
    {
        private readonly ICarRepository _carRepository;
        public CarList(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_carRepository.GetAllData());
        }
    }
}
