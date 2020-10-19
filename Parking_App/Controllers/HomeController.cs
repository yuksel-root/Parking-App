using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Parking_App.Entities;
using Parking_App.Interfaces;
using Parking_App.Models;

namespace Parking_App.Controllers
{

    public class HomeController : Controller
    {
        ICarRepository _carRepository;
      
        public HomeController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IActionResult Index()
        {
          
            return View(_carRepository.GetAllData());
        }

        public IActionResult CarExit(int id)
        {
            //ViewBag.Cookie = GetCookie("person");
            return View(_carRepository.GetWithId(id));
        }

        public IActionResult AddCar()
        {

            return View(new AddCarModel());
        }

        [HttpPost]
        public IActionResult AddCar(AddCarModel model)
        {

            Car car = new Car();
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    var path = Path.GetExtension(model.Image.FileName);
                    var newImageName = Guid.NewGuid() + path;
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory
                        (), "wwwroot/img/" + newImageName);

                    var stream = new FileStream(uploadPath, FileMode.Create);
                    model.Image.CopyTo(stream);

                    car.Image = newImageName;
                }

                car.Brand = model.Brand;
                car.Plate = model.Plate;
                car.Start_date = model.EntryDate;
                car.End_date = model.ExpireDate;
                _carRepository.Add(car);
                return RedirectToAction("Index", "Home");
            }
            
            return View(model);
        }

        public IActionResult UpdateCar(int id)
        {
            var incomingCar = _carRepository.GetWithId(id);

            UpdateCarModel model = new UpdateCarModel
            {
                Id = incomingCar.Id,
                Brand = incomingCar.Brand,
                Plate = incomingCar.Plate,
                EntryDate = incomingCar.Start_date,
                ExpireDate = incomingCar.End_date
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCar(UpdateCarModel model)
        {
            var updateCar = _carRepository.GetWithId(model.Id);

            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    var path = Path.GetExtension(model.Image.FileName);
                    var newImageName = Guid.NewGuid() + path;
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory
                        (), "wwwroot/img/" + newImageName);

                    var stream = new FileStream(uploadPath, FileMode.Create);
                    model.Image.CopyTo(stream);

                    updateCar.Image = newImageName;
                }
               
                updateCar.Brand = model.Brand;
                updateCar.Plate = model.Plate;
                updateCar.Start_date = model.EntryDate;
                updateCar.End_date = model.ExpireDate;
                _carRepository.Update(updateCar);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult RemoveCar(int id)
        {
            _carRepository.Remove(new Car { Id = id });

            return RedirectToAction("Index");
        }

       


    }
}
