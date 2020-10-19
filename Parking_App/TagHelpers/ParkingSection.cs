using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Parking_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_App.TagHelpers
{
    [HtmlTargetElement("getParkingSection")]
    public class ParkingSection : TagHelper
    {
        private readonly ICarRepository _carRepository;

        public ParkingSection(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public int CarId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var incomingParkings = _carRepository.GetParkings(CarId).Select(I => I.Section);

           foreach(var item in incomingParkings)
            {
                data += item + " ";
            }

            output.Content.SetContent(data);
        }
    }
}
