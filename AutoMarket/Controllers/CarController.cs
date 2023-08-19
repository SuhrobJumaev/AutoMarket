using AutoMarket.DAL.Interfaces;
using AutoMarket.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCars();
            
            if(response.StatusCode == Domain.Enum.StatusCode.InternalServerError)
            {
                return RedirectToAction("Error");
            } 

            return View(response.Data);
        }
    }
}
