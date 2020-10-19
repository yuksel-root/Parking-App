using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking_App.Interfaces;
using Parking_App.Models;

namespace Parking_App.Controllers
{
    public class ParkingController : Controller
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingController(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }
        public IActionResult Index()
        {
            return View(_parkingRepository.GetAllData());
        }

        public IActionResult AddParking()
        {
            return View(new AddParkingModel());
        }
        [HttpPost]
        public IActionResult AddParking(AddParkingModel model)
        {
            if (ModelState.IsValid)
            {
                _parkingRepository.Add(new Entities.Parking
                {
                    Section = model.Section
                });
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult UpdateParking(int id)
        {
            var updateParking = _parkingRepository.GetWithId(id);

            UpdateParkingModel model = new UpdateParkingModel
            {
                Id = updateParking.Id,
                Section = updateParking.Section
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateParking(UpdateParkingModel model)
        {
            if (ModelState.IsValid)
            {
                var updateParking = _parkingRepository.GetWithId(model.Id);
                updateParking.Section = model.Section;

                _parkingRepository.Update(updateParking);

                return RedirectToAction("Index", "Home");
            }

            return View(model);

        }
         
         public IActionResult RemoveParking(int id)
        {
            _parkingRepository.Remove(new Entities.Parking{Id = id});
            return RedirectToAction("Index");
        }


    }
}
